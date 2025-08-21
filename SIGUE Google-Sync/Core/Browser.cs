namespace GMapsSync.Core;

#nullable enable

using System;

using OpenQA.Selenium;

public enum Browser
{
    Chrome,
    Firefox
}

public static class BrowserExtensions
{
    public static Browser ToBrowser(this string displayName) => displayName switch
    {
        "Google Chrome" => Browser.Chrome,
        "Firefox" => Browser.Firefox,
        _ => Browser.Chrome
    };

    public static string Value(this Browser browser) => browser switch
    {
        Browser.Chrome => "Google Chrome",
        Browser.Firefox => "Firefox",
        _ => browser.ToString()
    };
}
