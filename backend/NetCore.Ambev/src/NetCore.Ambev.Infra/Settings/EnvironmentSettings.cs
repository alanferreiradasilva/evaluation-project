using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Ambev.Infra.Settings
{
    public static class EnvironmentSettings
    {
        public static string DefaultConnection
        {
            get => GetEnvironmentOrDefault("AMBEV_POSTGRES_CONNECTION");
        }

        public static string DefaultTestConnection
        {
            get => GetEnvironmentOrDefault("AMBEV_POSTGRES_CONNECTION_TEST");
        }

        private static string GetEnvironmentOrDefault(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.User) ?? string.Empty;
        }
    }
}
