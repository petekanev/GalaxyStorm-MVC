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

        public bool IsRead { get; set; }

        public Guid PlayerObjectId { get; set; }

        [ForeignKey("PlayerObjectId")]
        public PlayerObject PlayerObject { get; set; }

        public ReportType Type { get; set; }
    }

    public enum ReportType
    {
        Uncategorized = 0,
        Infrastructure = 1,
        Spy = 2,
        Attack = 3,
        Defense = 4,
        Server = 5
    }
}
