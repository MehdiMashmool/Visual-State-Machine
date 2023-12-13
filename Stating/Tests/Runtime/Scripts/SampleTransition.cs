using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using AS.Modules.Stating.Core;

namespace AS.Modules.Stating.Tests
{
    [UnitCategory("AS/Modules/Stating/Tests/Transitions")]
    public class SampleTransition : Transition<SampleStateTarget>
    {
        private float m_Delay = 5;
        private float m_PassedDelay = 0;
        private Coroutine m_Checking;

        protected override void OnStartListening(GraphStack stack)
        {
            m_Checking = StartCoroutine(Checking());
        }

        protected override void OnStopListening(GraphStack stack)
        {
            StopCoroutine(m_Checking);
            m_Checking = null;
        }

        private IEnumerator Checking()
        {
            while (Check())
            {
                yield return null;
            }

            DoTrigger();
            m_Checking = null;
        }

        private bool Check()
        {
            if (m_PassedDelay < m_Delay)
            {
                m_PassedDelay += Time.deltaTime;
                Debug.Log($"Waiting... Target: {Target}");
                return false;
            }
            else
            {
                Debug.Log($"Triggred! Target: {Target}");
                m_PassedDelay = 0;
                return true;
            }
        }
    }
}
