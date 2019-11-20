using Atividade04.Domain.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade04.Domain
{
    /// <summary>
    /// USER Class
    /// </summary>
    public class User
    {
        [BsonId, BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Login { get; set; }
        [BsonElement]
        public string Password { get; set; }
        [BsonElement]
        public UserRole Role { get; set; }
    }
}
