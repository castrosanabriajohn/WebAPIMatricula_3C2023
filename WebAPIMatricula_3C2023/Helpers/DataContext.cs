﻿using Microsoft.EntityFrameworkCore;
using WebAPIMatricula_3C2023.Entities;

namespace WebAPIMatricula_3C2023.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration) => (_configuration) = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            string bd = appSettings.BaseDatosSeguridad;
            options.UseSqlServer(Desencriptar(bd));
        }

        public static string Desencriptar(string pTexto)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(pTexto);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
