using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AstroAPI.Cache
{
    public class CacheItem
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Url { get; set; }
        public object Content { get; set; }
        public DateTime CachedAt { get; set; } = DateTime.Now;
        public DateTime expiresAt { get; set; } = DateTime.Now.AddDays(1);
    }
}