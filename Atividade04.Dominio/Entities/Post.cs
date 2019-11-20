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
    /// POST class
    /// </summary>
    public class Post
    {
        [BsonId, BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Title { get; set; }
        [BsonElement]
        public DateTime Date { get; set; }
        [BsonElement]
        public List<Section> Sections { get; set; }
    }
}
