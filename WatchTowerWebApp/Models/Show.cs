using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WatchTowerWebApp.Models
{
    public class Show
    {
        /*
         * The Show Model is the main focus of the App, it will aggregate 
         * information from the other Models to better display the data
         */
        public int Id { get; set; }

        //the show title is required and must be fewer than 50 characters
        [MaxLength(50, ErrorMessage = "Title is too long!")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        //the episode counts are not required, but I am limiting them to 1000 episode caps, I can't think of a show over 1000 episodes.
        [Range(0,1000, ErrorMessage = "Series must be less than 1000 episodes long")]
        [Display(Name = "Total Episodes")]
        public int TotalEpisode { get; set; }
        [Range(0, 1000, ErrorMessage = "invalid entry!")]
        [Display(Name = "Current Episode")]
        public int CurrentEpisode { get; set; }

        [Display(Name = "Next Release")]
        public DateTime NextRelease { get; set; }

        //FK fields
        //I do not believe any of these fields should be required, as you can watch a show alone
        //or have a show that does not yet have a place to be watched.
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        [Display(Name = "CoWatcher")]
        public int CoWatcherId { get; set; }

        //Parent Navigation properties for the Service and CoWatcher Models
        public Service Service { get; set; }
        public CoWatcher CoWatcher { get; set; }



    }
}
