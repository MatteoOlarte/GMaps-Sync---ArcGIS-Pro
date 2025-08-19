namespace GMapsSync;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

internal class MainModule : Module
{
    private static MainModule _this = null;

    /// <summary>
    /// Retrieve the singleton instance to this module here
    /// </summary>
    public static MainModule Current => _this ??= (MainModule)FrameworkApplication.FindModule("SIGUE_Google_Sync_Module");

    #region Overrides
    /// <summary>
    /// Called by Framework when ArcGIS Pro is closing
    /// </summary>
    /// <returns>False to prevent Pro from closing, otherwise True</returns>
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
    }
    #endregion Overrides
}

