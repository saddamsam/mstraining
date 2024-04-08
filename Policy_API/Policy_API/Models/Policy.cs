using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Policy_API.Models
{
    [Table("Policy")]
    public class Policy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("Policy_No")]
        public long PolicyNo { get; set; }
        [Column("Policy_Name")]
        public string PolicyName { get; set; } = string.Empty;
        [Column("From_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime FromDate { get; set; }
        [Column("To_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime ToDate { get; set; }
        [Column("Insured_Amount")]
        public long InsuredAmount { get; set; }

        [ForeignKey("PolicyHolder")]
        [Column("AdharCard_No_FK")]


        public string AdharCardNo { get; set; }
        [JsonIgnore]
        public PolicyHolder PolicyHolder { get; set; }

        [ForeignKey("Vehicle")]
        [Column("Registration_No_FK")]
     

        public string RegistrationNo { get; set; }
        [JsonIgnore]

        public Vehicle Vehicle { get; set; }

    }   
}

