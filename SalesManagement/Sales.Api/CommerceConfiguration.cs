using System;

namespace Sales.Api
{
    public class CommerceConfiguration
    {
        public readonly string ConnectionString;
        public readonly Type ProductRepositoryType;

        public CommerceConfiguration(string connectionString, string productRepositoryTypeName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(productRepositoryTypeName))
                throw new ArgumentNullException(nameof(productRepositoryTypeName));

            ConnectionString = connectionString;
            ProductRepositoryType = Type.GetType(productRepositoryTypeName, throwOnError: true);
        }
    }
}
