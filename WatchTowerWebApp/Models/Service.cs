using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WatchTowerWebApp.Models
{
    public class Service
    {
        /*
         * The Service Model holds information on the different services where shows can
         * be watched. This Model runs in a 1->many relationship with the Show Model.
        */
        public int Id { get; set; }

        //Name field is required, and must be fewer than 50 characters
        [MaxLength(50, ErrorMessage ="Service Name is too long!")]
        [Required(ErrorMessage = "Service Name is required")]
        public string Name { get; set; }

        //Type field is optional, but must be fewer than 50 characters
        [MaxLength(50, ErrorMessage = "Servcie type is too long!")]
        public string Type { get; set; }

        //Platform field is require and must be fewer than 50 characters
        [MaxLength(50, ErrorMessage = "Platform name is too long!")]
        [Required(ErrorMessage = "Platform name is required")]
        public string Platform { get; set; }

        [Display(Name = "Date to Renew")]
        public DateTime RenewalDate { get; set; }

        //Child navigation property with Show model
        public List<Show> Shows { get; set; }
    }
}
