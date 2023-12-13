using UnityEngine;
using Unity.VisualScripting;
using AS.Modules.Stating.Core;

namespace AS.Modules.Stating.Tests
{
    [UnitCategory("AS/Modules/Stating/Tests/States")]
    public class SampleAsyncState : AsyncState<SampleStateTarget>
    {
        protected override void OnEnter(Flow flow)
        {
            Debug.Log($"On Enter Async State. Target: {Target}");
            InvokeFinish();
        }

        protected override void OnUpdate(Flow flow)
        {
            Debug.Log($"On Update Async State. Target: {Target}");
        }

        protected override void OnExit(Flow flow)
        {
            Debug.Log($"On Exit Async State. Target: {Target}");
        }

        protected override void OnFinish()
        {
            Debug.Log($"On Finish Async State. Target: {Target}");
        }
    }
}
