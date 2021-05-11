﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30109.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ch16STEConsoleApp.STECustomerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ExtendedPropertiesDictionary", Namespace="http://schemas.datacontract.org/2004/07/BAGA", ItemName="ExtendedProperties", KeyName="Name", ValueName="ExtendedProperty")]
    [System.SerializableAttribute()]
    public class ExtendedPropertiesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsAddedToCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/BAGA", ItemName="AddedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="AddedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, Ch16STEConsoleApp.STECustomerService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectList", Namespace="http://schemas.datacontract.org/2004/07/BAGA", ItemName="ObjectValue")]
    [System.SerializableAttribute()]
    public class ObjectList : System.Collections.Generic.List<object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsRemovedFromCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/BAGA", ItemName="DeletedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="DeletedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, Ch16STEConsoleApp.STECustomerService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/BAGA", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    [System.SerializableAttribute()]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="STECustomerService.ICustomerSTEService")]
    public interface ICustomerSTEService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerSTEService/GetCustomerPickList", ReplyAction="http://tempuri.org/ICustomerSTEService/GetCustomerPickListResponse")]
        System.Collections.Generic.List<BAGA.CustomerNameAndID> GetCustomerPickList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerSTEService/GetUpcomingTrips", ReplyAction="http://tempuri.org/ICustomerSTEService/GetUpcomingTripsResponse")]
        System.Collections.Generic.List<BAGA.Trip> GetUpcomingTrips();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerSTEService/GetCustomer", ReplyAction="http://tempuri.org/ICustomerSTEService/GetCustomerResponse")]
        BAGA.Customer GetCustomer(int custID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerSTEService/SaveCustomer", ReplyAction="http://tempuri.org/ICustomerSTEService/SaveCustomerResponse")]
        string SaveCustomer(BAGA.Customer cust);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerSTEServiceChannel : Ch16STEConsoleApp.STECustomerService.ICustomerSTEService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerSTEServiceClient : System.ServiceModel.ClientBase<Ch16STEConsoleApp.STECustomerService.ICustomerSTEService>, Ch16STEConsoleApp.STECustomerService.ICustomerSTEService {
        
        public CustomerSTEServiceClient() {
        }
        
        public CustomerSTEServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerSTEServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerSTEServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerSTEServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<BAGA.CustomerNameAndID> GetCustomerPickList() {
            return base.Channel.GetCustomerPickList();
        }
        
        public System.Collections.Generic.List<BAGA.Trip> GetUpcomingTrips() {
            return base.Channel.GetUpcomingTrips();
        }
        
        public BAGA.Customer GetCustomer(int custID) {
            return base.Channel.GetCustomer(custID);
        }
        
        public string SaveCustomer(BAGA.Customer cust) {
            return base.Channel.SaveCustomer(cust);
        }
    }
}
