using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroAPI.Cache
{
    public class CacheService
    {
        private readonly string CONNECTION_STRING = Environment.GetEnvironmentVariable("MONGO_CONNECTION") ?? "mongodb://localhost:27017";
        private IMongoClient _db;
        private IMongoCollection<CacheItem> _collection;
        private readonly string DATABASE = "AstroCache";
        private readonly string COLLECTION_NAME = "cache";

        public CacheService()
        {
            _db = new MongoClient(CONNECTION_STRING);
            _collection = _db.GetDatabase(DATABASE).GetCollection<CacheItem>(COLLECTION_NAME);
        }


        public async Task<CacheItem> InsertItem(string url, object data)
        {
            var _item = new CacheItem { Url = url, Content = data };
            await _collection.InsertOneAsync(_item);
            return _item;
        }

        public async Task<CacheItem> GetItem(string url)
        {

            var filter = Builders<CacheItem>.Filter.Eq(nameof(CacheItem.Url), url);
            var rv = await _collection.Find(filter).FirstAsync();
            return rv;
        }
    }
}
