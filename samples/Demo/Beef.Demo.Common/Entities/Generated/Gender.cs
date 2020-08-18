/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options
#pragma warning disable CA2227, CA1819 // Collection/Array properties should be read only; ignored, as acceptable for a DTO.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Represents the Gender entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [ReferenceDataInterface(typeof(IReferenceData))]
    public partial class Gender : ReferenceDataBaseGuid
    {
        #region Privates

        private string? _alternateName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Alternate Name.
        /// </summary>
        [JsonProperty("alternateName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Alternate Name")]
        public string? AlternateName
        {
            get => _alternateName;
            set => SetValue(ref _alternateName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(AlternateName)); 
        }

        /// <summary>
        /// Gets or sets the Trip OData Code.
        /// </summary>
        [Display(Name="Trip Code")]
        public string? TripCode
        {
            get => GetMapping<string>(nameof(TripCode));
            set { var __tripCode = GetMapping<string>(nameof(TripCode)) ?? default; SetValue(ref __tripCode, value, true, StringTrim.UseDefault, StringTransform.UseDefault, nameof(TripCode)); SetMapping(nameof(TripCode), __tripCode!); }
        }

        #endregion

        #region Operator

        /// <summary>
        /// An implicit cast from an <b>Id</b> to a <see cref="Gender"/>.
        /// </summary>
        /// <param name="id">The <b>Id</b>.</param>
        /// <returns>The corresponding <see cref="Gender"/>.</returns>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Improves useability")]
        public static implicit operator Gender(Guid id)
        {
            return ConvertFromId<Gender>(id);
        }

        /// <summary>
        /// An implicit cast from a <b>Code</b> to a <see cref="Gender"/>.
        /// </summary>
        /// <param name="code">The <b>Code</b>.</param>
        /// <returns>The corresponding <see cref="Gender"/>.</returns>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Improves useability")]
        public static implicit operator Gender(string? code)
        {
            return ConvertFromCode<Gender>(code);
        }

        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="Gender"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Gender"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<Gender>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="Gender"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Gender"/> to copy from.</param>
        public void CopyFrom(Gender from)
        {
             if (from == null)
                 throw new ArgumentNullException(nameof(from));

            CopyFrom((ReferenceDataBaseGuid)from);
            AlternateName = from.AlternateName;
            TripCode = from.TripCode;

            OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="Gender"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="Gender"/>.</returns>
        public override object Clone()
        {
            var clone = new Gender();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="Gender"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            AlternateName = Cleaner.Clean(AlternateName, StringTrim.UseDefault, StringTransform.UseDefault);

            OnAfterCleanUp();
        }
    
        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                if (!base.IsInitial)
                    return false;

                return Cleaner.IsInitial(AlternateName);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(Gender from);

        #endregion
    } 

    /// <summary>
    /// Represents a <see cref="Gender"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class GenderCollection : ReferenceDataCollectionBase<Gender>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="GenderCollection"/> class.
        /// </summary>
        public GenderCollection(){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenderCollection"/> class with an entity range.
        /// </summary>
        /// <param name="entities">The <see cref="Gender"/> entities.</param>
        public GenderCollection(IEnumerable<Gender> entities) => AddRange(entities);

        #endregion
    }
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore