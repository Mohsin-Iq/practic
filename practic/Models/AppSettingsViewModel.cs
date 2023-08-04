using Microsoft.AspNetCore.Mvc;

namespace practic.Models
{
    public class AppSettingsViewModel
    {
        public LoggingOptions? Logging { get; set; }
    }

    public class LoggingOptions
    {
        public LogLevelOptions? LogLevel { get; set; }
    }

    public class LogLevelOptions
    {
        public string? Default { get; set; }
        [BindProperty(Name = "Microsoft.AspNetCore", SupportsGet =true)]
        public string? MicrosoftAspNetCore { get; set; }
    }
}
