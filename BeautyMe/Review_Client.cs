//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautyMe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review_Client
    {
        public int Review_Number { get; set; }
        public System.DateTime Review_Date { get; set; }
        public string Is_come { get; set; }
        public string Canceled_on_time { get; set; }
        public string Arrived_on_time { get; set; }
        public string Comment { get; set; }
        public string Professional_ID_number { get; set; }
        public string Client_ID_number { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Professional Professional { get; set; }
    }
}
