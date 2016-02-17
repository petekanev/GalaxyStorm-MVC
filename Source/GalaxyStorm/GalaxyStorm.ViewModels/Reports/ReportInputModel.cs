namespace GalaxyStorm.ViewModels.Reports
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.PlayerObjects;

    public class ReportInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Content { get; set; }

        [DisplayName("Shard")]
        public string ShardName { get; set; }

        public int ShardId { get; set; }

        public ReportType Type { get; set; }
    }
}
