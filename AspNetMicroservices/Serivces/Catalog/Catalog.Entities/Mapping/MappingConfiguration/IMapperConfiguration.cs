using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Mapping.MappingConfiguration
{
    public interface IMapperConfiguration
    {
        IMapper GetMapper();
    }
}
