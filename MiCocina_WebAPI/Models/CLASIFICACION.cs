//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiCocina_WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLASIFICACION
    {
        public int IdClasificacion { get; set; }
        public Nullable<int> IdRecetas { get; set; }
        public string Calificacion { get; set; }
    
        public virtual RECETA RECETA { get; set; }
    }
}
