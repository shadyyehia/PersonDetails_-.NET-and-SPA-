using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PersonDetails.Models;

namespace PersonDetails.Models
{
    public class MongoDbDocument
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }  // Use ObjectId for MongoDB

        // Convert ObjectId to string
        [BsonIgnore]
        public string Id
        {
            get { return ObjectId.ToString(); }
            set { ObjectId = new ObjectId(value); }
        }
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("telephone Number")]
        public string TelephoneNumber { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        public Person MapMongoPersonToPerson()
        {
            var nameParts = this.Name.Split(' ');

            return new Person
            {
                first_name = nameParts.Length > 0 ? nameParts[0] : string.Empty,
                last_name = nameParts.Length > 1 ? nameParts[1] : string.Empty,
                telephone_code = this.TelephoneNumber.Split('-')[0],
                telephone_number = this.TelephoneNumber.Split('-')[1],
                address = this.Address,
                country = this.Country
            };
        }
    }
}
