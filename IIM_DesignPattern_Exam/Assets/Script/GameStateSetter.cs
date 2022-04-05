using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSetter : MonoBehaviour
{
    [SerializeField] GameState _gameState;
    [SerializeField] GameStateReference _gameStateRef;

    #region EDITOR

    private void Reset()
    {
        _gameState = GetComponent<GameState>();
    }

    #endregion

    private void Awake()
    {
        IReferenceSetter<GameState> gameStateRef = _gameStateRef;
        gameStateRef.SetInstance(_gameState);
    }
}
