using AgroPec.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Data;
using System.IO;

namespace AgroPec.DbContext
{
    public class AppDbContext : IDisposable
    {
        private MySql.Data.MySqlClient.MySqlConnection _connection;

        public AppDbContext()
        {
            var connectionString = GetConnectionString();
            _connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        }

        private string GetConnectionString()
        {
            // Define a configuração para ler o appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            return config.GetConnectionString("DefaultConnection");
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public MySql.Data.MySqlClient.MySqlCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }
    }
}
