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
    
    public partial class UserContent
    {
        public int UserContentId { get; set; }
        public string Keyword { get; set; }
        public System.Guid UserId { get; set; }
        public string Catagory { get; set; }
        public string Def { get; set; }
        public string Exa { get; set; }
        public System.DateTime DateAdd { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}