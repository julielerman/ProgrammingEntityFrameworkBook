
using System.Runtime.Serialization;

namespace POCO.State
{

  [DataContract(IsReference = true)]
  public class StateObject
  {
    [DataMember]
    public State State { get; set; }


  }
}

