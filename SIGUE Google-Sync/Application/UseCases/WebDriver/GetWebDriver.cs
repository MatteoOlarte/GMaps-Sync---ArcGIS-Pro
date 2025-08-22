namespace GMapsSync.Application.UseCases.WebDriver;

using System;
using System.IO;

using GMapsSync.Application.Ext.StringExtensions;
using GMapsSync.Application.Services;
using GMapsSync.Core;

public class GetWebDriver
{
    public static WebDriverHelper Invoke()
    {
        var path = MainModule.Settings.driver_path;
        var browser = MainModule.Settings.web_browser.ToBrowser();
    
        if (path.IsNullOrEmpty())
        {
            throw new ArgumentException("El camino del driver no puede ser nulo o vacío.", nameof(path));
        }
        if (!Directory.Exists(path) && !File.Exists(path))
        {
            throw new ArgumentException($"El path especificado no existe: {path}", nameof(path));
        }
        try
        {
            return new WebDriverHelper(browser, path);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"No se pudo crear el WebDriver: {ex.Message}", ex);
        }
    }
}
