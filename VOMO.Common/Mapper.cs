using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOMO.Common
{
    public static class Mapper
    {
        private readonly static List<Mapping> Mappings = new List<Mapping>();

        public static void Register<TSource, TDestination>(Func<object, object> mappingFunction)
            where TSource : class
            where TDestination : class
        {
            var mappingFunc = Mappings.SingleOrDefault(map => map.SourceType == typeof(TSource) && map.DestinationType == typeof(TDestination));

            if (mappingFunc != null)
                mappingFunc.MapFunc = mappingFunction;
            else
                Mappings.Add(new Mapping { SourceType = typeof(TSource), DestinationType = typeof(TDestination), MapFunc = mappingFunction });
        }

        public static TDestination Map<TSource, TDestination>(TSource src)
            where TSource : class
            where TDestination : class
        {
            var mappingFunc = Mappings.SingleOrDefault(map => map.SourceType == typeof(TSource) && map.DestinationType == typeof(TDestination));
            if (mappingFunc == null)
                throw new Exception("Invalid mapping: no mapping found for requested types.");

            return mappingFunc.MapFunc(src) as TDestination;
        }

        public static List<TDestination> Map<TSource, TDestination>(List<TSource> srcEnumerable)
            where TSource : class
            where TDestination : class
        {
            var mappingFunc = Mappings.SingleOrDefault(map => map.SourceType == typeof(TSource) && map.DestinationType == typeof(TDestination));
            if (mappingFunc == null)
                throw new Exception("Invalid mapping: no mapping found for requested types.");

            return srcEnumerable.Select(srcSingle => mappingFunc.MapFunc(srcSingle) as TDestination).ToList();
        }

        public static TDestination Map<TDestination>(object src)
            where TDestination : class
        {
            var mappingFunc = Mappings.SingleOrDefault(map => map.SourceType == src.GetType() && map.DestinationType == typeof(TDestination));
            if (mappingFunc == null)
                throw new Exception("Invalid mapping: no mapping found for requested types.");

            return mappingFunc.MapFunc(src) as TDestination;
        }
    }
}
