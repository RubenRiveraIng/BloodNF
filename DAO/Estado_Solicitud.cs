//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estado_Solicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado_Solicitud()
        {
            this.Solicitud_Recoleccion = new HashSet<Solicitud_Recoleccion>();
        }
    
        public int IdEstado_Solicitud { get; set; }
        public string Nombre { get; set; }
    
        public virtual Estado_Solicitud Estado_Solicitud1 { get; set; }
        public virtual Estado_Solicitud Estado_Solicitud2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Recoleccion> Solicitud_Recoleccion { get; set; }
    }
}
