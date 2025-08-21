namespace GMapsSync;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

using GMapsSync.Core;

internal class MainModule : Module
{
    private static MainModule _this = null;
    private static Settings _settings = Settings.Default;
    public static MainModule Current => _this ??= (MainModule)FrameworkApplication.FindModule("SIGUE_Google_Sync_Module");
    public static Settings Settings => _settings;


    protected override bool CanUnload()
    {
        return true;
    }

    protected override bool Initialize()
    {
        return base.Initialize();
    }

    protected override void Uninitialize()
    {
        base.Uninitialize();
        Application.Services.WebDriverHelper.CloseAll(); // Ensure all WebDriver instances are closed
    }
}
