//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace paddle.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string user_id { get; set; }
        public string pwd { get; set; }
    
        public virtual user user1 { get; set; }
        public virtual user user2 { get; set; }
    }
}