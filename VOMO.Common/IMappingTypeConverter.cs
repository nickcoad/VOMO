using System;
using System.Collections.Generic;
using System.Linq;

namespace VOMO.Common
{
    public interface IMappingTypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source, MappingConfig mappingConfig);
        TDestination Convert(TSource source, TDestination destination, MappingConfig mappingConfig);
    }
}
