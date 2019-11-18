using Atividade04.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4.Infra
{
    public static class Helper
    {
        public static readonly IMongoClient client;
        private static readonly string _connectionString = "mongodb://localhost:27017";
        private static readonly string _defaultDatabase = "Atividade04";

        public static IMongoClient GetMongoClient()
        {
            return client ?? createMongoClient();
        }

        private static IMongoClient createMongoClient()
        {
            return new MongoClient(MongoClientSettings.FromConnectionString(_connectionString));
        }

        public static IMongoDatabase GetDatabase()
        {
            return GetMongoClient().GetDatabase(_defaultDatabase);
        }

        public static IMongoCollection<T> GetCollection<T>()
        {
            return GetDatabase().GetCollection<T>(typeof(T).Name);
        }

        public static async Task InsertOneAsync<T>(T document)
        {
            await GetCollection<T>().InsertOneAsync(document);
        }

        public static async Task ReplaceOneAsync<T>(Expression<Func<T, bool>> expression, T document)
        {
            await GetCollection<T>().ReplaceOneAsync(expression, document);
        }
    }
}
