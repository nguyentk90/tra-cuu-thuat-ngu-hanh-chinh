//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TraCuuThuatNgu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string HeadWord { get; set; }
        public string CmContent { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
    
        public virtual Entry Entry { get; set; }
        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
