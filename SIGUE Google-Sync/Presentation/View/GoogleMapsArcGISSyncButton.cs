namespace GMapsSync.Presentation.View;

using System;

using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;

using GMapsSync.Presentation.ViewModel;

internal class GoogleMapsArcGISSyncButton : Button
{
    private readonly GoogleMapsArcGISSyncViewModel viewModel;

    public GoogleMapsArcGISSyncButton()
    {
        viewModel = new GoogleMapsArcGISSyncViewModel();
    }

    protected override void OnClick() => QueuedTask.Run(this.HandleClick);

    private void HandleClick()
    {
        try
        {
            this.viewModel.SyncToArcGIS();
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Error al sincronizar con Google Maps: {ex.Message}", "Error");
        }
    }
}
