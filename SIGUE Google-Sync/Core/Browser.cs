namespace GMapsSync.Core;

public enum Browser
{
    Chrome,
    Firefox
}

public static class BrowserExtensions
{
    public static string Value(this Browser browser) => browser switch
    {
        Browser.Chrome => "Google Chrome",
        Browser.Firefox => "Firefox",
        _ => browser.ToString()
    };

    public static Browser From(string displayName) => displayName switch
    {
        "Google Chrome" => Browser.Chrome,
        "Firefox" => Browser.Firefox,
        _ => Browser.Chrome
    };
}
