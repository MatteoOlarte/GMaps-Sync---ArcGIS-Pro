namespace GMapsSync.Application.UseCases.WebDriver;

using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class GetWebDriver
{
    public static IWebDriver Invoke()
    {
        var path = @"C:\Users\molarte\PycharmProjects\QGIS-StreetView\gmaps_sigue\drivers\chromedriver.exe";
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("El camino del driver no puede ser nulo o vacío.", nameof(path));
        }
        return new ChromeDriver(path);
    }
}
