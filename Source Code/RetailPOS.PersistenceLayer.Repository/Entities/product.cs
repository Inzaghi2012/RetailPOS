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
    public partial class product : EntityBase
    {
        #region Primitive Properties
    
        public virtual short id
        {
            get;
            set;
        }
    
        public virtual string barcode
        {
            get;
            set;
        }
    
        public virtual string name
        {
            get;
            set;
        }
    
        public virtual string description
        {
            get;
            set;
        }
    
        public virtual short status_id
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> retail_price
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> wholesale_price
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> tax_rate
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> has_waranty
        {
            get;
            set;
        }
    
        public virtual string image_path
        {
            get;
            set;
        }
    
        public virtual Nullable<short> category_id
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> size
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> weight
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<orderchild> orderchilds
        {
            get
            {
                if (_orderchilds == null)
                {
                    var newCollection = new FixupCollection<orderchild>();
                    newCollection.CollectionChanged += Fixuporderchilds;
                    _orderchilds = newCollection;
                }
                return _orderchilds;
            }
            set
            {
                if (!ReferenceEquals(_orderchilds, value))
                {
                    var previousValue = _orderchilds as FixupCollection<orderchild>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixuporderchilds;
                    }
                    _orderchilds = value;
                    var newValue = value as FixupCollection<orderchild>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixuporderchilds;
                    }
                }
            }
        }
        private ICollection<orderchild> _orderchilds;
    
        public virtual ICollection<wastemanagement> wastemanagements
        {
            get
            {
                if (_wastemanagements == null)
                {
                    var newCollection = new FixupCollection<wastemanagement>();
                    newCollection.CollectionChanged += Fixupwastemanagements;
                    _wastemanagements = newCollection;
                }
                return _wastemanagements;
            }
            set
            {
                if (!ReferenceEquals(_wastemanagements, value))
                {
                    var previousValue = _wastemanagements as FixupCollection<wastemanagement>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupwastemanagements;
                    }
                    _wastemanagements = value;
                    var newValue = value as FixupCollection<wastemanagement>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupwastemanagements;
                    }
                }
            }
        }
        private ICollection<wastemanagement> _wastemanagements;

        #endregion
        #region Association Fixup
    
        private void Fixuporderchilds(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (orderchild item in e.NewItems)
                {
                    item.product = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (orderchild item in e.OldItems)
                {
                    if (ReferenceEquals(item.product, this))
                    {
                        item.product = null;
                    }
                }
            }
        }
    
        private void Fixupwastemanagements(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (wastemanagement item in e.NewItems)
                {
                    item.product = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (wastemanagement item in e.OldItems)
                {
                    if (ReferenceEquals(item.product, this))
                    {
                        item.product = null;
                    }
                }
            }
        }

        #endregion
    }
}
