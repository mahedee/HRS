using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class RoomType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250, MinimumLength = 2)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int GaleryId { get; set; }
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Price must Required")]
        public double Price { get; set; }

    }
}