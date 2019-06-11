using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MovieBrowser.Models
{
    public class SettingsQuery : IRequest<Settings>
    {
    }

    public class SettingsQueryHandler : IRequestHandler<SettingsQuery, Settings>
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;

        public SettingsQueryHandler(IConfiguration configuration, IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public Task<Settings> Handle(SettingsQuery request, CancellationToken cancellationToken)
        {
            Settings settings = null;
            var settingsFile = configuration.GetValue("SettingsFilePath", ".\\settings.json");

            if (File.Exists(settingsFile))
            {
                var fileContent = File.ReadAllText(settingsFile);
                settings = JsonConvert.DeserializeObject<Settings>(fileContent);
            }

            if (settings == null || string.IsNullOrEmpty(settings.MoviesFolderPath))
            {
                settings = new Settings
                {
                    MoviesFolderPath = env.ContentRootPath
                };
            }
            
            return Task.FromResult(settings);
        }
    }

    public class SettingsCommand : IRequest<bool>
    {
        public Settings Settings { get; set; }
    }

    public class SettingsCommandHandler : IRequestHandler<SettingsCommand, bool>
    {
        private readonly IConfiguration configuration;

        public SettingsCommandHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<bool> Handle(SettingsCommand request, CancellationToken cancellationToken)
        {
            var settingsFile = configuration.GetValue("SettingsFilePath", ".\\settings.json");
            if (File.Exists(settingsFile))
            {
                var fileContent = File.ReadAllText(settingsFile);
                var settings = JsonConvert.DeserializeObject<Settings>(fileContent);
                if(request.Settings.MoviesFolderPath != settings.MoviesFolderPath)
                {
                    settings.MoviesFolderPath = request.Settings.MoviesFolderPath;
                    File.WriteAllText(settingsFile, JsonConvert.SerializeObject(settings));
                }
            }
            else
            {
                File.WriteAllText(settingsFile, JsonConvert.SerializeObject(request.Settings));
            }

            return Task.FromResult(true);
        }
    }

    public class Settings
    {
        public string MoviesFolderPath { get; set; }
    }

}
