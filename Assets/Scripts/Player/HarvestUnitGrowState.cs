using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestUnitGrowState : BaseState<HarvestUnit>
{
    float growTime = 0f;
    int currentValue = 0;
    public override void EnterState(HarvestUnit harvestUnit)
    {
        growTime = harvestUnit.unitData.Time;
        currentValue = 0;
        harvestUnit.PlayAnimation();
    }

    public override void ExitState(HarvestUnit harvestUnit)
    {
    }

    public override void FixedUpdateState(HarvestUnit harvestUnit)
    {
    }

    public override void UpdateState(HarvestUnit harvestUnit)
    {
        growTime -= Time.deltaTime;
        if (growTime <= 0f)
        {
            if(currentValue < harvestUnit.unitData.MaxValue)
            {
                currentValue++;
                growTime = harvestUnit.unitData.Time;
                Debug.Log("Current Value: " + currentValue);
            }
            else
            {
                harvestUnit.SwitchState(harvestUnit.ripeState);
            }
        }
    }
}
