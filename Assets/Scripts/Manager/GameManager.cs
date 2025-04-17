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
    }
    void Start()
    {
        // Initialize the game state to Ingame
        SetGameState(GameState.Ingame);
    }
    void Update()
    {

    }
    public void SetGameState(GameState newState)
    {
        currentState = newState;
    }
}
 