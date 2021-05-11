//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Runtime.Serialization;

namespace POCO.State
{
 
    [DataContract(IsReference = true)]
    public class StateObject
    {
        [DataMember]
        public State State { get; set; }

        //[OnSerializing]
        //internal void SetUnchanged(StreamingContext context)
        //{
        //  if (this.State == null)
        //  {
        //    this.State = State.Unchanged;
        //  }
        //}
    }
}
    
