using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalExam.Database_Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }


        [Required]
        [MaxLength(100)]
        [Display(Name ="Book Name")]
        public string BookName { get; set; } 


        [Required]
        [MaxLength(100)]
        public string Author { get; set; } 


        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
