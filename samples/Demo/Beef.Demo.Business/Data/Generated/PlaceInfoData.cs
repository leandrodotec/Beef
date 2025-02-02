/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.WebApi;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the <see cref="PlaceInfo"/> data access.
    /// </summary>
    public partial class PlaceInfoData
    {

        /// <summary>
        /// Provides the <see cref="PlaceInfo"/> and HttpAgent <see cref="Model.PlaceInfo"/> <i>AutoMapper</i> mapping.
        /// </summary>
        public partial class HttpAgentMapperProfile : AutoMapper.Profile
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HttpAgentMapperProfile"/> class.
            /// </summary>
            public HttpAgentMapperProfile()
            {
                var s2d = CreateMap<PlaceInfo, Model.PlaceInfo>();
                s2d.ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
                s2d.ForMember(d => d.PostCode, o => o.MapFrom(s => s.PostCode));

                var d2s = CreateMap<Model.PlaceInfo, PlaceInfo>();
                d2s.ForMember(s => s.Name, o => o.MapFrom(d => d.Name));
                d2s.ForMember(s => s.PostCode, o => o.MapFrom(d => d.PostCode));

                HttpAgentMapperProfileCtor(s2d, d2s);
            }

            partial void HttpAgentMapperProfileCtor(AutoMapper.IMappingExpression<PlaceInfo, Model.PlaceInfo> s2d, AutoMapper.IMappingExpression<Model.PlaceInfo, PlaceInfo> d2s); // Enables the constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore