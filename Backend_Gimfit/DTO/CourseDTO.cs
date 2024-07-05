namespace Backend_Gimfit.DTO
{
    public class CourseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public int SubscriptionId { get; set; }
        public TrainerDTO Trainer { get; set; }
    }
}
