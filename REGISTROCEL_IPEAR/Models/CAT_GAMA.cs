//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REGISTROCEL_IPEAR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_GAMA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_GAMA()
        {
            this.REG_DISPOSITIVO = new HashSet<REG_DISPOSITIVO>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal costo_ensamblaje { get; set; }
        public bool activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REG_DISPOSITIVO> REG_DISPOSITIVO { get; set; }
    }
}
