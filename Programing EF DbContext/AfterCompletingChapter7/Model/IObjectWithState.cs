using System.Collections.Generic;

namespace Model
{
  public interface IObjectWithState
  {
    State State { get; set; }
  }

  public enum State
  {
    Added,
    Unchanged,
    Deleted
  }
}