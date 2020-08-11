using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Microservice.Entities
{
    public class ApplicationUser : BaseEntities
    {
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "First Name Cannot exceed 50 Characters")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name Cannot exceed 50 Characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Emai Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Reporting To")]
        public string ReportingTo { get; set; }
        [Required]
        [Display(Name = "User Type")]
        public UserType? UserTypes { get; set; }
        [Required]
        [Display(Name = "User Status")]
        public Status? Stat { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        public long MobileNumber { get; set; }
    }
}
