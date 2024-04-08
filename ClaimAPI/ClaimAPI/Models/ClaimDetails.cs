using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimAPI.Models
{
    public enum ReportedStatus { YES,NO }

    [Table("ClaimDetails")]
    public class ClaimDetails
    {
        [Key]
        [Column("ClaimNo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClaimNo { get; set; }

        [Column("PolicyNo")]
        public long PolicyNo { get; set; }

        [Column("EventTime")]
        [DataType(DataType.DateTime)]
        public DateTime EventTime { get; set; }

        [Column("Speed",TypeName = "Int")]
        public int Speed { get; set; }

        [Column("PlaceOccured", TypeName = "Varchar(200)")]
        public string PlaceOccured { get; set; }
        
        [Column("PlaceHeading", TypeName = "Varchar(200)")]
        public string PlaceHeading { get; set; }
        
        [Column("Purpose", TypeName = "Varchar(200)")]
        public string Purpose { get; set; }
        
        [Column("PeopleCount", TypeName = "Int")]
        public int PeopleCount { get; set; }
        
        [Column("IsReportedToPolice")]
        [EnumDataType(enumType:typeof(ReportedStatus))]
        public ReportedStatus IsReportedToPolice { get; set; }

       

        [ForeignKey("LicenseDetails")]
        [Column("DL_FK")]
        public string DLNO { get; set; }
        public LicenseDetails LicenseDetails { get; set; }
        

        [ForeignKey("FIRDetails")]
        [Column("FIRNO_FK")]
        public string FIRNO { get; set; }
        public FIRDetails FIRDetails { get; set; }
    }
}
