using System;
using System.Collections.Generic;
using System.Linq;
using Halcyon.HAL.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Halcyon.HAL.Json
{
    public class JsonHalAttributesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            // Ignore properties w/ HalEmbedded attribute
            return
                properties.Where(p => !p.AttributeProvider.GetAttributes(typeof(HalEmbeddedAttribute), true).Any())
                    .ToList();
        }
    }
}
