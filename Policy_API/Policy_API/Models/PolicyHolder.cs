using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Policy_API.Models
{

    public enum Gender { MALE,FEMALE,TRANSGENDER,NONINVDIVIDUAL}

    //public class PolicyHolder(string aadharNo)
    [Table("PolicyHolder")]
    public class PolicyHolder
    {
        //public string AadharCardNo { get; set; } = aadharNo;

        [Key]
        [Column("Adhar_Card",TypeName = "Varchar(25)")]
        public string AadharCardNo { get; set; } = string.Empty;

        public FullName? Name { get; set; }

        [Column("Gender")]
        [EnumDataType(enumType: typeof(Gender))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }


        //public DateOnly? DOB { get; set; }
        [Column("DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [Column("Email")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email Format")]
        [DefaultValue(false)]
        public string Email { get; set; } = String.Empty;

        [Column("MobileNo")]
        [RegularExpression("^([+]\\d{2}[ ])?[6789]\\d{9}$", ErrorMessage = "Invalid Mobile Number")]
        public long MobileNo { get; set; }


    }
}
