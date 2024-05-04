using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Settings
    {
        private readonly IConfiguration _config;

        public Settings()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public string GetDbSettings()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
    }
}
