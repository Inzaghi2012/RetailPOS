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
    public partial class display_properties : EntityBase
    {
        #region Primitive Properties
    
        public virtual short product_id
        {
            get;
            set;
        }
    
        public virtual string text_color
        {
            get;
            set;
        }
    
        public virtual short font_size
        {
            get;
            set;
        }
    
        public virtual bool text_bold
        {
            get;
            set;
        }
    
        public virtual bool display_in_screen
        {
            get;
            set;
        }

        #endregion
    }
}
