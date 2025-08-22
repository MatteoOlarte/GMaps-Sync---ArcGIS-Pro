namespace GMapsSync.Presentation.View;

using System;

using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;

using GMapsSync.Presentation.ViewModel;

internal class ArcGISGoogleMapsSyncButton : Button
{
    private readonly ArcGISGoogleMapsSyncViewModel viewModel;

    public ArcGISGoogleMapsSyncButton()
    {
        this.viewModel = new ArcGISGoogleMapsSyncViewModel();
    }
    protected override void OnClick() => QueuedTask.Run(this.HandleClick);

    private void HandleClick()
    {
        try
        {
            this.viewModel.SyncGoogleMapsView();
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Error al sincronizar con Google Maps: {ex.Message}", "Error");
        }
    }
}
