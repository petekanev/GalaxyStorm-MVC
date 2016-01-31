namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime ReceivedOn { get; set; }

        public Guid PlayerObjectId { get; set; }

        [ForeignKey("PlayerObjectId")]
        public PlayerObject PlayerObject { get; set; }
    }
}
