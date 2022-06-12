using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MedicationManager.Data.Common.Documents
{
    [BsonIgnoreExtraElements]
    public abstract class DocumentBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
