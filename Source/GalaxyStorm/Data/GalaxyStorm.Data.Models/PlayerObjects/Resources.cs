namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Resources
    {
        public long Energy { get; set; }

        public long Crystal { get; set; }

        public long Metal { get; set; }
    }
}
