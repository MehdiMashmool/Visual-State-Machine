using Unity.VisualScripting;

namespace AS.Modules.Stating.Core
{
    public abstract class State<T> : BaseUnit<T> where T : Target
    {
        [DoNotSerialize] private ControlInput m_OnEnter;
        [DoNotSerialize] private ControlInput m_OnUpdate;
        [DoNotSerialize] private ControlInput m_OnExit;
        [DoNotSerialize] private ControlInput m_OnFinishInput;
        [DoNotSerialize] private ControlOutput m_OnFinishOutput;

        private GraphReference m_GraphReference;

        protected override void Definition()
        {
            m_OnEnter = ControlInput("Do Enter", EnterOutpu);
            m_OnUpdate = ControlInput("Do Update", UpdateOutput);
            m_OnExit = ControlInput("Do Exit", ExitOutput);
            m_OnFinishInput = ControlInput("Do Finish", Finish);
            m_OnFinishOutput = ControlOutput("On Finish");
        }

        public sealed override void Instantiate(GraphReference instance)
        {
            base.Instantiate(instance);
            m_GraphReference = instance;
            OnInitialize(Flow.New(instance));
        }

        protected virtual void OnInitialize(Flow flow) { }

        protected abstract ControlOutput Enter(Flow flow);

        protected abstract ControlOutput Exit(Flow flow);

        protected virtual ControlOutput Update(Flow flow) { return null; }

        protected virtual void OnFinish() { }

        protected void InvokeFinish()
        {
            OnFinish();
            Invoke(m_OnFinishOutput);
        }

        protected void Invoke(ControlOutput control)
        {
            Flow flow = Flow.New(m_GraphReference);
            flow.Invoke(control);
        }

        private ControlOutput EnterOutpu(Flow flow)
        {
            return Enter(flow);
        }

        private ControlOutput UpdateOutput(Flow flow)
        {
            return Update(flow);
        }

        private ControlOutput ExitOutput(Flow flow)
        {
            return Exit(flow);
        }

        private ControlOutput Finish(Flow flow)
        {
            OnFinish();
            return m_OnFinishOutput;
        }
    }
}
