namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime ReceivedOn { get; set; }
    }
}
