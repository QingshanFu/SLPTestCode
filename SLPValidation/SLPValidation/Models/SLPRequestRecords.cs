namespace SLPValidation.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLPRequestRecords")]
    public partial class SLPRequestRecords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public string RequestID { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string OPPID { get; set; }
        public string Amendment { get; set; }
        [Required]
        public int Status { get; set; }
        public string Notes { get; set; }
        public DateTime? ValidationTime { get; set; }
        public string ValidationResult { get; set; }
        public string ScannedFile { get; set; }

        public string StatusText
        {
            get
            {
                switch(this.Status)
                {
                    case 0:
                        return "Pending";
                    case 1:
                        return "Validation Pass";
                    case 2:
                        return "Validation Fail";
                }

                return "Unknown";
            }
        }
    }
}
