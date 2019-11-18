using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Atividade04.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atividade4.Infra.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldGetDatabase()
        {
            var database = Helper.GetDatabase();
            Assert.IsTrue(database != null);
        }

        [TestMethod]
        public void ShouldGetCollection()
        {
            var collection = Helper.GetCollection<Blog>();
            Assert.IsTrue(collection != null);
        }

        [TestMethod]
        public void ShouldInsertOneAsync()
        {
            var tasks = new List<Task>();

            // insere
            tasks.Add(Helper.InsertOneAsync(new Blog { Description = "test blog - lucas paga cuca" }));
            tasks.Add(Helper.InsertOneAsync(new User { Login = "eliton.gadotti", Name = "Eliton", Password = "thatsallfolks" }));

            Task.WaitAll(tasks.ToArray());

            // confere
            //...
        }

        [TestMethod]
        public void ShouldReplaceOneAsync()
        {
            var @object = new User { Login = "eliton.gadotti", Name = "Eliton", Password = "noOneCares" };
            Expression<Func<User, bool>> filterExpression = x => x.Login == "eliton.gadotti";

            var task = Helper.ReplaceOneAsync(filterExpression, @object);
            Task.WaitAll(task);
            Assert.IsTrue(true);
        }
    }
}
