using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using AS.Modules.Stating.Core;

namespace AS.Modules.Stating.Tests
{
    [UnitCategory("AS/Modules/Stating/Tests/Transitions")]
    public class SampleTransition : Transition<SampleStateTarget>
    {
        [DoNotSerialize] private ValueInput m_Key;

        private KeyCode m_KeyCode;
        private Coroutine m_Checking;

        protected override void OnInitialize(Flow flow)
        {
            m_KeyCode = flow.GetValue<KeyCode>(m_Key);
        }

        protected override void Definition()
        {
            base.Definition();
            m_Key = ValueInput<KeyCode>("Key");
        }

        protected override void OnStartListening(GraphStack stack)
        {
            m_Checking = StartCoroutine(Checking());
        }

        protected override void OnStopListening(GraphStack stack)
        {
            if (m_Checking != null)
            {
                StopCoroutine(m_Checking);
                m_Checking = null;
            }
        }

        private IEnumerator Checking()
        {
            while (!Check())
            {
                yield return null;
            }

            DoTrigger();
            Debug.Log($"Triggred! Target: {Target}");
            m_Checking = null;
        }

        private bool Check()
        {
            return Input.GetKeyDown(m_KeyCode);
        }
    }
}
