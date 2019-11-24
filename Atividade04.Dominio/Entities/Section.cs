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
    /// SECTION class
    /// </summary>
    public class Section
    {
        [BsonId, BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        /// <summary>
        /// To order the content
        /// </summary>
        [BsonElement]
        public int Order { get; set; }

        [BsonElement]
        public string Title { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [BsonElement]
        public string Content { get; set; }

        /// <summary>
        /// Sections []
        /// </summary>
        [BsonElement]
        public List<Subsection> Subsections { get; set; }
    }
}
