namespace GalaxyStorm.Web.Utilities
{
    using AutoMapper;

    public static class AutomapperExtensions
    {
        public static TDestination Map<TSource, TDestination>(this TDestination destination, TSource source)
        {
            return Mapper.Map(source, destination);
        }
    }
}