using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace AS.Modules.Stating.Core
{
    public abstract class Transition<T> : EventUnit<EmptyEventArgs> where T : Target
    {
        protected sealed override bool register => true;

        protected T Target { private set; get; }

        private GraphReference m_GraphReference;
        private EmptyEventArgs m_EmptyEventArgs = new EmptyEventArgs();

        public sealed override void StartListening(GraphStack stack)
        {
            base.StartListening(stack);
            OnStartListening(stack);
        }

        public sealed override void StopListening(GraphStack stack)
        {
            base.StopListening(stack);
            OnStopListening(stack);
        }

        public override EventHook GetHook(GraphReference reference)
        {
            return EventHooks.Custom;
        }

        public override void Instantiate(GraphReference instance)
        {
            base.Instantiate(instance);
            m_GraphReference = instance;
            Target = instance.gameObject.GetComponent<T>();
            OnInitialize(Flow.New(instance));
        }

        protected virtual void OnInitialize(Flow flow) { }

        protected abstract void OnStartListening(GraphStack stack);

        protected abstract void OnStopListening(GraphStack stack);

        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            return Target.StartCoroutine(routine);
        }

        protected void StopCoroutine(Coroutine routine)
        {
            Target.StopCoroutine(routine);
        }

        protected void DoTrigger()
        {
            Trigger(m_GraphReference, m_EmptyEventArgs);
        }
    }
}
