//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RetailPOS.PersistenceLayer.Repository.Entities
{
    public partial class login_history : EntityBase
    {
        #region Primitive Properties
    
        public virtual long id
        {
            get;
            set;
        }
    
        public virtual Nullable<short> staff_id
        {
            get;
            set;
        }
    
        public virtual Nullable<int> customer_id
        {
            get;
            set;
        }
    
        public virtual System.DateTime login_date
        {
            get;
            set;
        }
    
        public virtual string ip
        {
            get;
            set;
        }
    
        public virtual string host
        {
            get;
            set;
        }

        #endregion
    }
}
