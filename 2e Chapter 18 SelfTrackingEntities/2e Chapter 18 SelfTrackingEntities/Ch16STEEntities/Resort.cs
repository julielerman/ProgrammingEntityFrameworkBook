//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace BAGA
{
    [DataContract(IsReference = true)]
    public partial class Resort : Lodging, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string ResortChainOwner
        {
            get { return _resortChainOwner; }
            set
            {
                if (_resortChainOwner != value)
                {
                    _resortChainOwner = value;
                    OnPropertyChanged("ResortChainOwner");
                }
            }
        }
        private string _resortChainOwner;
    
        [DataMember]
        public bool LuxuryResort
        {
            get { return _luxuryResort; }
            set
            {
                if (_luxuryResort != value)
                {
                    _luxuryResort = value;
                    OnPropertyChanged("LuxuryResort");
                }
            }
        }
        private bool _luxuryResort;

        #endregion
        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
        }

        #endregion
    }
}
