@"
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data.Common;

namespace $($namespace)
{
    public class Config
    {
        static IConfiguration configBuilder = null;

        static IConfiguration getConfigBuilder()
        {
            if (configBuilder == null)
            {
                configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            }

            return configBuilder;
        }
        static public string getString(string param)
        {
            string result = string.Empty;

            if (param == "db.connection")
            {
                result = getDbConnection();
            }
            else
            {
                IConfigurationSection section = getConfigBuilder().GetSection("appsettings");
                result = section[param];
            }

            return result;
        }

        static public string getDbConnection()
        {
            // var connString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
            string dbcon = "Host=^server;Username=^username;Password=^password;Database=^database;";
           // string dbcon = "Server=^server;Database=^database;User Id=^username;Password=^password";

            string server = Environment.GetEnvironmentVariable("SQLCMDSERVER");
            string database = Environment.GetEnvironmentVariable("SQLCMDDATABASE");
            string username = Environment.GetEnvironmentVariable("SQLCMDUSER");
            string password = Environment.GetEnvironmentVariable("SQLCMDPASSWORD");

            dbcon = dbcon.Replace("^server", server);
            dbcon = dbcon.Replace("^database", database);
            dbcon = dbcon.Replace("^username", username);
            dbcon = dbcon.Replace("^password", password);


            return dbcon;

        }
        static public int getInt(string param)
        {
            IConfigurationSection section = getConfigBuilder().GetSection("appsettings");

            return Convert.ToInt32(section[param]);
        }
    }
}
"@