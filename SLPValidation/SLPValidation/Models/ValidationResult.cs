namespace SLPValidation.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ValidationResult")]
    public partial class ValidationResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public string RequestID { get; set; }
        [Required]
        public string RuleDescription { get; set; }
        [Required]
        public int Result { get; set; }
        public string DocumentName { get; set; }
        public string FieldName { get; set; }
        public string Expected { get; set; }
        public string Actual { get; set; }

        public string ResultText
        {
            get
            {
                switch(this.Result)
                {
                    case 0:
                        return "Fail";
                    case 1:
                        return "Pass";
                }

                return "Unknown";
            }
        }
    }
}
