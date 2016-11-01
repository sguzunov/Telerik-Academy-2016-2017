using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
