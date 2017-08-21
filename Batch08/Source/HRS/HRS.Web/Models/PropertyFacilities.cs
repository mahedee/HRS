using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Web.Models
{
    public class PropertyFacility
    {
        public PropertyFacility()//Create Constructor for many to many relationship
        {
            this.Properties = new HashSet<Property>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Facility Name")]
        public string FacilitiesName { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}