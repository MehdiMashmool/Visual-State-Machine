using UnityEngine;
using Unity.VisualScripting;

namespace AS.Modules.Stating.Core
{
    public abstract class SyncState<T> : State<T> where T : Target
    {
        protected sealed override ControlOutput Enter(Flow flow)
        {
            OnEnter(flow);
            return null;
        }

        protected sealed override ControlOutput Update(Flow flow)
        {
            OnUpdate(flow);
            return null;
        }

        protected sealed override ControlOutput Exit(Flow flow)
        {
            OnExit(flow);
            return null;
        }

        protected abstract void OnEnter(Flow flow);

        protected virtual void OnUpdate(Flow flow) { }

        protected abstract void OnExit(Flow flow);
    }
}
