using System.ComponentModel.DataAnnotations;

namespace webapp.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }

        [Required]
        public string DisplayOrder { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
