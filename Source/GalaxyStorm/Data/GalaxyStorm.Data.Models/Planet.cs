namespace GalaxyStorm.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Planet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public double EnergyModifier { get; set; }

        public double CrystalModifier { get; set; }

        public double MetalModifier { get; set; }

        public bool IsPopulated { get; set; }

        public int ShardId { get; set; }

        [ForeignKey("ShardId")]
        public virtual Shard Shard { get; set; }
    }
}
