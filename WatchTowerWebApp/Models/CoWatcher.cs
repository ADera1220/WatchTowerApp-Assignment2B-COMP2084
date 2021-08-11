using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WatchTowerWebApp.Models
{
    public class CoWatcher
    {
        /*
         * The CoWatcher Model exists to allow a user to kepp track if they are watching a show with another person.
         * The original idea was to have groups, but integrating that became more difficult than I was willing to
         * attempt. CoWatcher and Show are in a 1-->many relationship, as a single CoWatcher can be on many Shows
        */

        // Id Field for CoWacther
        public int Id { get; set; }

        //FirstName field for CoWatcher, input validation will ensure a valid first name between 2 and 20 characters is required
        [MinLength(2, ErrorMessage = "First name cannot be less than 2 characters long")]
        [MaxLength(20, ErrorMessage="First name cannot be more than 20 characters long")]
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //LastName field for CoWatcher, input validation will ensure a valid last name between 2 and 20 characters is required
        [MinLength(2, ErrorMessage = "Last name cannot be less than 2 characters long")]
        [MaxLength(20, ErrorMessage = "Last name cannot be more than 20 characters long")]
        [Required(ErrorMessage ="Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //WatchTime field is to help coordinate what day/time the person is next available to watch an episode
        [Display(Name = "Next Watch Date")]
        public DateTime WatchTime { get; set; }

        //Child Navigation property, linking with the Show Model
        public List<Show> Shows { get; set; }
    }
}
