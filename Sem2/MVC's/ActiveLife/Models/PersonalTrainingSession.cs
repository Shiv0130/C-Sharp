namespace ActiveLife.Models
{
    public class PersonalTrainingSession
    {
        public int Id { get; set; }
        public DateTime SessionDateTime { get; set; }
        public int DurationMinutes { get; set; }
        public decimal SessionFee { get; set; }
        public string WorkoutFocus { get; set; } = string.Empty;
        public int TrainerId { get; set; }
        public FitnessTrainer? Trainer { get; set; }
        public int GymMemberId { get; set; }
        public GymMember? GymMember { get; set; }
    }
}