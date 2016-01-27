namespace GalaxyStorm.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shard
    {
        private ICollection<Planet> planets;

        public Shard()
        {
            this.planets = new HashSet<Planet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ShardSize ShardSize { get; set; }

        public virtual ICollection<Planet> Planets { get { return this.planets; } set { this.planets = value; } }

        public double BuildSpeed { get; set; }

        public bool IsLocked { get; set; }
    }
}
