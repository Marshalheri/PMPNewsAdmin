//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMPAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Advert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
