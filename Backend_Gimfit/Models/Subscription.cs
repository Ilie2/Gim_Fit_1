using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_Gimfit.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        // Remove the [Required] attribute if you want Courses to be optional
        // [Required(ErrorMessage = "The Courses field is required.")]
        [JsonIgnore]
        public virtual List<Course> Courses { get; set; }
    }
}
