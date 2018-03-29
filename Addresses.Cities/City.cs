// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.Cities
{
    /// <summary>Contains US City component of addresses</summary>
    [ProtoBufSerializable]
    [Table("Cities", Schema = "Addresses")]
    public class City : IStaticEntity<City, int>
    {
        public City()
        {
        }

        public City(string name)
        {
            Name = name;
        }

        /// <summary>City unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int CityId { get; set; }

        /// <summary>Contains Name value</summary>
        [Position(2)]
        public string Name { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 8;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => CityId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<City, object>> GetUniqueIndex() => entity => new { entity.Name };
    }
}
