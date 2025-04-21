using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestUnitRipeState : BaseState<HarvestUnit>
{
    public override void EnterState(HarvestUnit player)
    {
        Debug.Log("Ripe State Entered");
    }

    public override void ExitState(HarvestUnit player)
    {
    }

    public override void FixedUpdateState(HarvestUnit player)
    {
    }

    public override void UpdateState(HarvestUnit player)
    {
    }
}
