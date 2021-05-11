using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POCO.State
{
    public enum State
    {
         Unchanged, Added ,Modified,Deleted
    }

    public static class StateHelpers
    {
        public static EntityState GetEquivalentEntityState(State state)
        {
            //this handy method comes from Rowan Miller on the EF team!
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}

