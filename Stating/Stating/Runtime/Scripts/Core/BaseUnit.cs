using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

namespace AS.Modules.Stating.Core
{
    public abstract class BaseUnit<T> : Unit where T : Target
    {
        protected T Target { private set; get; }

        public override void Instantiate(GraphReference instance)
        {
            base.Instantiate(instance);
            Target = instance.gameObject.GetComponent<T>();
        }

        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            return Target.StartCoroutine(routine);
        }

        protected void StopCoroutine(Coroutine routine)
        {
            Target.StopCoroutine(routine);
        }
    }
}
