
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data.Common;

namespace legr3
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
    // Path to the .legr3 file in the user's home directory
    string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    string filePath = Path.Combine(homeDirectory, ".legr3");

    // Check if the file exists
    if (!File.Exists(filePath))
    {
        throw new FileNotFoundException("The .legr3 file was not found in the user's home directory.", filePath);
    }

    // Read the file content
    string fileContent = File.ReadAllText(filePath).Trim();

    // Split the content by colon (:) to extract parameters
    string[] parameters = fileContent.Split(':');
    if (parameters.Length != 4)
    {
        throw new FormatException("The .legr3 file must contain exactly four parameters separated by colons (:).");
    }

    string server = parameters[0];
    string database = parameters[1];
    string username = parameters[2];
    string password = parameters[3];

    // Create the connection string
    string dbcon = "Host=^server;Username=^username;Password=^password;Database=^database;";
    dbcon = dbcon.Replace("^server", server)
                 .Replace("^database", database)
                 .Replace("^username", username)
                 .Replace("^password", password);

    return dbcon;
}
        static public int getInt(string param)
        {
            IConfigurationSection section = getConfigBuilder().GetSection("appsettings");

            return Convert.ToInt32(section[param]);
        }
    }
}