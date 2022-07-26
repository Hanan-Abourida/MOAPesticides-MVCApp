//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pesticides.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PesticidesInfo
    {
        public int PesticidesInfoPk { get; set; }
        public Nullable<int> fkPesticideType { get; set; }
        public Nullable<int> fkActiveIngredient { get; set; }
        public Nullable<int> fkFormulation { get; set; }
        public Nullable<int> fkToxicityFish { get; set; }
        public Nullable<int> fkToxicityBees { get; set; }
        public Nullable<int> fkToxicityBirds { get; set; }
        public Nullable<int> fkClassWHO { get; set; }
        public string ModeOfAction { get; set; }
        public Nullable<int> fkCrop { get; set; }
        public Nullable<int> fkPest { get; set; }
        public string RatePerLiters { get; set; }
        public string RatePerHectar { get; set; }
        public Nullable<int> PreharvestInterval { get; set; }
        public string ModeOfUse { get; set; }
    
        public virtual ActiveIngredient ActiveIngredient { get; set; }
        public virtual Crop Crop { get; set; }
        public virtual Formulation Formulation { get; set; }
        public virtual Pest Pest { get; set; }
        public virtual ToxicityClassWHO ToxicityClassWHO { get; set; }
        public virtual PesticideType PesticideType { get; set; }
        public virtual ToxicityOnFish ToxicityOnFish { get; set; }
        public virtual ToxicityOnBee ToxicityOnBee { get; set; }
        public virtual ToxicityOnBird ToxicityOnBird { get; set; }
    }
}
