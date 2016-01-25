namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Technologies
    {
        public int ArmorFleetLevel { get; set; }

        public int FasterConstructionLevel { get; set; }

        public int CheaperFleetLevel { get; set; }

        public int LargerFleetLevel { get; set; }

        public int MoreResourcesLevel { get; set; }
    }
}
