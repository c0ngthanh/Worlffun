using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    float timer = 0;
    float maxTimer =1;
    // private int idleHash = Animator.StringToHash("Idle");
    public override void EnterState(Player player)
    {

    }

    public override void ExitState(Player player)
    {
    }

    public override void FixedUpdateState(Player player)
    {
    }

    public override void UpdateState(Player player)
    {
        if(timer < 0){
            timer = maxTimer;
            player.Mining();
            if(math.distancesq(player.playerVisual.transform.position, LevelManager.Instance.checkPointList[player.playerAttribute.currentLevel-1].position) > 0.1)
            {
                player.playerMoveState.SetTarget(LevelManager.Instance.checkPointList[player.playerAttribute.currentLevel-1].position);
                player.SwitchState(player.playerMoveState);
            }
        }
        timer-=Time.deltaTime;
    }
}
