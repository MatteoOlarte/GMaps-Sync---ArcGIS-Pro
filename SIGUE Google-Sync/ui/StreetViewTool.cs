namespace GMapsSync.Controls;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

using ArcGIS.Core.CIM;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

#nullable enable

internal class StreetViewTool : MapTool
{
    private record Cords(double Latitude, double Longitude, double Heading);
    private MapPoint? point0, point1;
    private bool isMousePressed, isDrawingLine;
    private IDisposable? pointGraphic, lineGraphic;

    public StreetViewTool()
    {
        this.point0 = null;
        this.point1 = null;
        this.isMousePressed = false;
        this.isDrawingLine = false;
    }

    protected override void OnToolMouseDown(MapViewMouseButtonEventArgs e)
    {
        if (e.ChangedButton == System.Windows.Input.MouseButton.Left) e.Handled = true;
    }

    protected override void OnToolMouseUp(MapViewMouseButtonEventArgs e)
    {
        if (e.ChangedButton == System.Windows.Input.MouseButton.Left) e.Handled = true;
    }

    protected override Task HandleMouseDownAsync(MapViewMouseButtonEventArgs e) => QueuedTask.Run(() => handleMousePressEvent(e));

    protected override Task HandleMouseUpAsync(MapViewMouseButtonEventArgs e) => QueuedTask.Run(() => handleMouseUpEvent(e));

    protected override void OnToolMouseMove(MapViewMouseEventArgs e) => this.handleMouseMoveEvent(e);

    private async void handleMousePressEvent(MapViewMouseButtonEventArgs e)
    {
        if (this.isMousePressed)
        {
            return;
        }

        this.isMousePressed = true;
        this.point0 = MapView.Active.ClientToMap(e.ClientPoint);

        await QueuedTask.Run(() =>
        {
            if (pointGraphic != null)
            {
                pointGraphic.Dispose();
                pointGraphic = null;
            }

            var pointSymbol = SymbolFactory.Instance.ConstructPointSymbol(
                ColorFactory.Instance.CreateRGBColor(0, 255, 255),
                8,
                SimpleMarkerStyle.Cross
            );

            var symbolReference = new CIMSymbolReference
            {
                Symbol = pointSymbol
            };

            pointGraphic = MapView.Active.AddOverlay(point0, symbolReference);
        });
    }

    private void handleMouseMoveEvent(MapViewMouseEventArgs e)
    {
        if (!this.isMousePressed)
        {
            return;
        }

        if (!this.isDrawingLine)
        {
            this.isDrawingLine = true;
        }

        _ = DrawLineAsync(e.ClientPoint);
    }

    private async void handleMouseUpEvent(MapViewMouseButtonEventArgs e)
    {
        if (!this.isMousePressed)
        {
            return;
        }

        this.isMousePressed = false;
        this.point1 = MapView.Active.ClientToMap(e.ClientPoint);

        await QueuedTask.Run(() =>
        {
            pointGraphic?.Dispose();
            pointGraphic = null;

            lineGraphic?.Dispose();
            lineGraphic = null;

            if (point0 is not null && point1 is not null)
            {
                var cords = this.CalculateStreetViewParams(this.point0, this.point1);
                this.OpenGoogleStreetView(cords);
            }
        });
    }

    private async Task DrawLineAsync(Point clientPoint)
    {
        await QueuedTask.Run(() =>
        {
            if (this.lineGraphic != null)
            {
                this.lineGraphic.Dispose();
                this.lineGraphic = null;
            }

            var current = MapView.Active.ClientToMap(clientPoint);
            var polyline = PolylineBuilderEx.CreatePolyline([this.point0, current]);
            var strokeA = SymbolFactory.Instance.ConstructStroke(
                ColorFactory.Instance.CreateRGBColor(0, 0, 0),
                0.75
            );
            var strokeB = SymbolFactory.Instance.ConstructStroke(
                ColorFactory.Instance.CreateRGBColor(0, 255, 255),
                0.75
            );
            var lineSymbol = new CIMLineSymbol
            {
                SymbolLayers = [strokeA, strokeB]
            };

            strokeA.Effects = [
                new CIMGeometricEffectDashes{DashTemplate = [3.0, 3.0]} // Dash 3px, Gap 3px
            ];

            strokeB.Effects = [
                new CIMGeometricEffectDashes{DashTemplate = [3.0, 3.0], OffsetAlongLine = 3.0}
            ];

            this.lineGraphic = MapView.Active.AddOverlay(polyline, new CIMSymbolReference { Symbol = lineSymbol });
        });
    }

    private Cords CalculateStreetViewParams(MapPoint start, MapPoint end)
    {
        // Calcular el ángulo entre los dos puntos
        double deltaX = end.X - start.X;
        double deltaY = end.Y - start.Y;
        double angleRadians = Math.Atan2(deltaX, deltaY);

        // Convertir a grados y ajustar al rango 0-360
        double angleDegrees = angleRadians * (180.0 / Math.PI);
        if (angleDegrees < 0) angleDegrees += 360.0;

        // Transformar el punto inicial a WGS84 (EPSG:4326)
        var spatialReference = SpatialReferenceBuilder.CreateSpatialReference(4326);
        var transformedGeometry = GeometryEngine.Instance.Project(start, spatialReference);

        if (transformedGeometry is not MapPoint transformedPoint)
            throw new InvalidOperationException("Error al transformar coordenadas.");

        return new Cords(transformedPoint.Y, transformedPoint.X, angleDegrees);
    }

    private void OpenGoogleStreetView(Cords p)
    {
        var url = $"https://www.google.com/maps/@?api=1&map_action=pano&viewpoint={p.Latitude},{p.Longitude}&heading={p.Heading}&pitch=0&fov=120";
        
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
}
