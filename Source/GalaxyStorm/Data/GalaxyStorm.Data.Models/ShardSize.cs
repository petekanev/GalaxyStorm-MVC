namespace GalaxyStorm.Data.Models
{
    /// <summary>
    /// Defines the shard/cluster/server size
    /// based on which a grid system will be populated
    /// </summary>
    public enum ShardSize
    {
        Small = 0, // -> 5x5
        Medium = 1, // -> 7x7
        Large = 2, // -> 10x10
        Gigantic = 3 // -> 15x15
    }
}
