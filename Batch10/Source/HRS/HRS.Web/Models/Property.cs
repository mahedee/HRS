using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Web.Models
{
    public class Property
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public int PropertyTypeId { get; set; }
        [ForeignKey("PropertyTypeId")]
        public virtual PropertyType PropertyType { get; set; }


        [Required(ErrorMessage ="Property Name is required")]
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Property address is required")]
        [Display(Name = "Property Address")]
        public string PropertyAdd { get; set; }

        
        [Display(Name = "Property Description")]
        public string PropertyDesc { get; set; }

        public int RatingId { get; set; }
        [ForeignKey("RatingId")]
        public virtual Rating Rating { get; set; }


        public Boolean Facilities { get; set; }
        public string Image { get; set; }

    }
}