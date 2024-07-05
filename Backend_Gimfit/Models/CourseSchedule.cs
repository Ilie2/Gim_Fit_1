using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_Gimfit.Models
{
    public class CourseSchedule
    {
        public int ID { get; set; }
        public int CourseId { get; set; }
        public virtual Course ScheduledCourse { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public virtual List<Client> Clients { get; set; }
    }
}
