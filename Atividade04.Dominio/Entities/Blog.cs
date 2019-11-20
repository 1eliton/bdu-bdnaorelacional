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
    /// BLOG class
    /// </summary>
    public class Blog
    {
        [BsonId, BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Title { get; set; }
        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public User User { get; set; }
        [BsonElement]
        public List<Post> Posts { get; set; }
    }
}
