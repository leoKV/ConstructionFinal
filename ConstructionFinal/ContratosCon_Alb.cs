//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructionFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContratosCon_Alb
    {
        public int codigoCAlb { get; set; }
        public int codigoC { get; set; }
        public int codigoAl { get; set; }
        public byte[] contrato { get; set; }
        public Nullable<bool> estatusCon { get; set; }
    
        public virtual Albaniles Albaniles { get; set; }
        public virtual Contratistas Contratistas { get; set; }
    }
}
