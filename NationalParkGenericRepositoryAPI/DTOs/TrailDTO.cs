using NationalParkGenericRepositoryAPI.Models;
using System.ComponentModel.DataAnnotations;
using static NationalParkGenericRepositoryAPI.Models.Trail;

namespace NationalParkGenericRepositoryAPI.DTOs
{
    public class TrailDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        public string Elevation { get; set; }
        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }
    }
}
