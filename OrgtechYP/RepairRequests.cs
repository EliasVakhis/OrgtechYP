//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrgtechYP
{
    using System;
    using System.Collections.Generic;
    
    public partial class RepairRequests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RepairRequests()
        {
            this.ActiveRequests = new HashSet<ActiveRequests>();
            this.Comments = new HashSet<Comments>();
        }
    
        public int RequestID { get; set; }
        public System.DateTime StartDate { get; set; }
        public int EquipmentID { get; set; }
        public string ProblemDescription { get; set; }
        public int StatusID { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public int CustomerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActiveRequests> ActiveRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Users Users { get; set; }
        public virtual Statuses Statuses { get; set; }
    }
}
