using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        //pk
        public int ID { get; set; }
        [Required(ErrorMessage ="Last Name is Required")]
        [StringLength(30,ErrorMessage ="Last Name can't be more than 30 chars")]
        [Display(Name ="Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$",ErrorMessage ="Last Name must start with Upper Chars")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(30, ErrorMessage = "First Name can't be more than 30 chars")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First Name must start with Upper Chars")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        //navigation property
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}