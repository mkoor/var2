//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace var2
{
    using System;
    using System.Collections.Generic;
    
    public partial class AutopartsSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AutopartsSet()
        {
            this.OrdersSet = new HashSet<OrdersSet>();
        }
    
        public int Id { get; set; }
        public string CategoryAutopart { get; set; }
        public string NameAutopart { get; set; }
        public string AutoBrand { get; set; }
        public string Manufacturer { get; set; }
        public int IdSupplier { get; set; }
    
        public virtual SuppliersSet SuppliersSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersSet> OrdersSet { get; set; }
    }
}
