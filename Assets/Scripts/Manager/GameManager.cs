using System;
using UnityEngine;
public enum GameState
{
    Ingame,
    Combat
}
public class GameManager : Singleton<GameManager>
{
    public GameState currentState;
    protected override void Awake()
    {
        base.Awake();
        if(CSVReader.Instance == null){
            CSVReader.Instance = new CSVReader();
        }
        CSVReader.Instance.ConvertAll();
        for(int i = 0; i < UnitData.Table.Length; i++)
        {
            Debug.Log(UnitData.Table[i].ID + " " + UnitData.Table[i].unitName + " " + UnitData.Table[i].health + " " + UnitData.Table[i].damage);
        }
    }
    void Start()
    {
        // Initialize the game state to Ingame
        SetGameState(GameState.Ingame);
    }
    public void StartCombat(UnitAttribute unit1, UnitAttribute unit2)
    {
        // Create the combat UI
        CombatManager.Instance.InitializeCombat(unit1, unit2);
        UIManager.Instance.CreateUI("CombatUI");
        // Initialize the combat manager with the two units
    }
    void Update()
    {

    }
    public void SetGameState(GameState newState)
    {
        currentState = newState;
    }
    public void StartCombat(){
        SetGameState(GameState.Combat);
        StartCombat(new UnitAttribute(Player.Instance.playerAttribute), new UnitAttribute());
    }
}
 