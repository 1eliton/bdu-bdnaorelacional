using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade04.Domain
{
    public class Subsection
    {
        [BsonId, BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Title { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [BsonElement]
        public string Content { get; set; }
    }
}
