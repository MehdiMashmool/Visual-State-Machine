using UnityEngine;
using Unity.VisualScripting;
using AS.Modules.Stating.Core;

namespace AS.Modules.Stating.Tests
{
    [UnitCategory("AS/Modules/Stating/Tests/States")]
    public class SampleSyncState : SyncState<SampleStateTarget>
    {
        protected override void OnEnter(Flow flow)
        {
            Debug.Log($"On Enter Sync State. Target: {Target}");
        }

        protected override void OnUpdate(Flow flow)
        {
            Debug.Log($"On Update Sync State. Target: {Target}");
        }

        protected override void OnExit(Flow flow)
        {
            Debug.Log($"On Exit Sync State. Target: {Target}");
        }

        protected override void OnFinish()
        {
            Debug.Log($"On Finish Sync State. Target: {Target}");
        }
    }
}
