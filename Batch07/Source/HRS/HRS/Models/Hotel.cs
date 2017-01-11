using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Hotel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250, MinimumLength=2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address must require")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "E-mail is require")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage="Mobile number is require")]
        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [Required(ErrorMessage="Website is require")]
        [StringLength(200)]
        public string Website { get; set; }

        public string Description { get; set; }
        
        [StringLength(1000)]
        [Display(Name="Logo")]
        public string LogoURL { get; set; }

    }
}