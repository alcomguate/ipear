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
    
    public partial class CAT_FABRICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_FABRICA()
        {
            this.REG_DISPOSITIVO = new HashSet<REG_DISPOSITIVO>();
        }
    
        public short id { get; set; }
        public string nombre { get; set; }
        public string pais { get; set; }
        public short ciudad { get; set; }
        public string direccion { get; set; }
        public string telefonos { get; set; }
        public short orden { get; set; }
        public bool activo { get; set; }
    
        public virtual CAT_CIUDAD CAT_CIUDAD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REG_DISPOSITIVO> REG_DISPOSITIVO { get; set; }
    }
}
