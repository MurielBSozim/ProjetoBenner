//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoBenner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agendado
    {
        public int Codigo_Agendado { get; set; }
        public Nullable<int> Codigo_Agenda { get; set; }
        public Nullable<int> Codigo_Pessoa { get; set; }
        public Nullable<int> Codigo_Medico { get; set; }
        public Nullable<int> Codigo_Local { get; set; }
        public Nullable<int> Codigo_Pre_Consulta { get; set; }
        public Nullable<System.DateTime> Data_Consulta { get; set; }
        public Nullable<System.TimeSpan> Hora_Consulta { get; set; }
        public Nullable<bool> Consulta_Confirmada { get; set; }
    
        public virtual Agenda Agenda { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Local Local { get; set; }
        public virtual Pre_Consulta Pre_Consulta { get; set; }
    }
}
