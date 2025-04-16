using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Singleton<Player>
{
    public GameObject playerVisual;
    public PlayerIdleState playerIdleState;
    public PlayerMoveState playerMoveState;
    private PlayerBaseState currentState;
    public PlayerAttribute playerAttribute;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerIdleState = new PlayerIdleState();
        playerMoveState = new PlayerMoveState();
        currentState = playerIdleState;
        playerAttribute = new PlayerAttribute();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }
    public void SwitchState(PlayerBaseState newState)
    {
        if (currentState == newState) return;
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public void Mining(){
        Vector2 value = LevelManager.Instance.GetValue();
        playerAttribute.Money += value.x;
        playerAttribute.Experience += value.y;
    }
    public void MoveToNextLevel(){
        playerAttribute.currentLevel++;
        Debug.Log("Current Level: " + playerAttribute.currentLevel);
        if(playerAttribute.currentLevel > LevelManager.Instance.checkPointList.Length)
        {
            playerAttribute.currentLevel = 1;
        }
    }
    public PlayerBaseState GetPlayerState()
    {
        return currentState;
    }
}
