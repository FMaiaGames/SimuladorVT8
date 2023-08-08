using System;
using TMPro;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance;
    public enum GameState
    {
        WirePlacement,
        PowerConnection,
        ParameterPhase,
        EndGame
    }
    public GameState State;

    public static event Action<GameState> OnStateChanged;

    [SerializeField] private TMP_Text _gameStateDisplay;

    private void Awake(){Instance = this;}

    private void Start()
    {
        UpdateGameState(GameState.WirePlacement);
    }

    public void UpdateGameState(GameState newGameState)
    {
        State = newGameState;

        switch (newGameState)
        {
            case GameState.WirePlacement:
                _gameStateDisplay.text = $"1 - Conexão dos cabos";
                break;
            case GameState.PowerConnection:
                _gameStateDisplay.text = $"2 - Alimentação de energia";
                break;
            case GameState.ParameterPhase:
                _gameStateDisplay.text = $"3 - Programação dos parâmetros";
                break;
            case GameState.EndGame:
                break;

        }

        OnStateChanged?.Invoke(newGameState);

    }

    public void IncrementState()
    {
        State = GameState.PowerConnection;

        UpdateGameState(State);
    }



}
