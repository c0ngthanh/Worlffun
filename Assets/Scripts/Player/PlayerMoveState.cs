using Unity.Mathematics;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private Vector3 targetPosition;
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
        if(math.distancesq(player.playerVisual.transform.position,targetPosition)<0.1)
        {
            player.SwitchState(player.playerIdleState);
        }else{
            player.playerVisual.transform.position = Vector3.MoveTowards(player.playerVisual.transform.position, targetPosition, 2 * Time.deltaTime);
        }
    }
    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
    }
}
