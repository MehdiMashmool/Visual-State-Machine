using UnityEngine;
using Unity.VisualScripting;

namespace AS.Modules.Stating.Core
{
    public abstract class AsyncState<T> : State<T> where T : Target
    {
        [DoNotSerialize] public ControlOutput m_OnEnterOutput;
        [DoNotSerialize] public ControlOutput m_OnUpdateOutput;
        [DoNotSerialize] public ControlOutput m_OnExitOutput;

        protected sealed override ControlOutput Enter(Flow flow)
        {
            OnEnter(flow);
            return m_OnEnterOutput;
        }

        protected sealed override ControlOutput Update(Flow flow)
        {
            OnUpdate(flow);
            return m_OnUpdateOutput;
        }

        protected sealed override ControlOutput Exit(Flow flow)
        {
            OnExit(flow);
            return m_OnExitOutput;
        }

        protected override void Definition()
        {
            base.Definition();
            m_OnEnterOutput = ControlOutput("On Enter");
            m_OnUpdateOutput = ControlOutput("On Update");
            m_OnExitOutput = ControlOutput("On Exit");
        }

        protected abstract void OnEnter(Flow flow);

        protected virtual void OnUpdate(Flow flow) { }

        protected abstract void OnExit(Flow flow);
    }
}
