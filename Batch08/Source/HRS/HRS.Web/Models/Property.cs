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
        public Property()//create for many to many relationship
        {
            this.PropertyFacilities = new HashSet<PropertyFacility>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CountryId { get; set; }

        
        [ForeignKey("CountryId")]
        [Display(Name = "Country")]
        public virtual Country Country { get; set; }


        public int CityId { get; set; }
        
        [ForeignKey("CityId")]
        [Display(Name = "City")]
        public virtual City City { get; set; }

        public int PropertyTypeId { get; set; }
        [ForeignKey("PropertyTypeId")]
        [Display(Name = "Property Type")]
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
        [Display(Name = "Ratings")]
        public virtual Rating Rating { get; set; }


        public bool Facilities { get; set; }
        public string Image { get; set; }

        public virtual ICollection<PropertyFacility> PropertyFacilities { get; set; }

    }
}