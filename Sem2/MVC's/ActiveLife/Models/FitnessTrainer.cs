namespace ActiveLife.Models
{
    public class FitnessTrainer
    {
        public int Id { get; set; }
        public string TrainerName { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public ICollection<PersonalTrainingSession> Sessions { get; set; } = new List<PersonalTrainingSession>();
    }
}