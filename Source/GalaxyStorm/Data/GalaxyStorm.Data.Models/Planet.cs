namespace GalaxyStorm.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Planet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        /// <summary>
        /// A value from 1 to 0 that amplifies energy resource generation
        /// </summary>
        public double EnergyModifier { get; set; }

        /// <summary>
        /// A value from 1 to 0 that amplifies crystal resource generation
        /// </summary>
        public double CrystalModifier { get; set; }

        /// <summary>
        /// A value from 1 to 0 that amplifies metal resource generation
        /// </summary>
        public double MetalModifier { get; set; }

        public bool IsPopulated { get; set; }
    }
}
