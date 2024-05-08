﻿using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
