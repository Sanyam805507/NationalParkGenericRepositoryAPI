using System.ComponentModel.DataAnnotations;

namespace NationalParkWEBAPP.Models
{
    public class Trail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        public string Elevation { get; set; }
        public enum DifficultyType { Easy, Moderate, Difficult }
        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }
    }
}
