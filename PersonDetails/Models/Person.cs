using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PersonDetails.Models
{
    public class Person
    {
        
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telephone_code { get; set; }
        public string telephone_number { get; set; }
        public string address { get; set; }
        public string country { get; set; }
    }
}
