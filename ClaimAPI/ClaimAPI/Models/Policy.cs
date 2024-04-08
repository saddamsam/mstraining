using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ClaimAPI.Models
{
    public class Policy
    {
        [BsonId]
        public long PolicyNo { get; set; }
        public string PolicyName { get; set; } 
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public long InsuredAmount { get; set; }
        public string AdharCardNo { get; set; }
        public string RegistrationNo { get; set; }


    }
}
