using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;


[CustomEditor(typeof(GameManager))]
public class GameManagerButtons : Editor {

    public override void OnInspectorGUI() {

        GameManager gm = (GameManager)target;

        if (GUILayout.Button("Next Player"))
        {
            gm.NextTurn();
            //Debug.Log("is player one: " + gm.isPlayerOne);
        }

        DrawDefaultInspector();
    }
} // end GameManagerButtons class
#endif

[Serializable]
public enum GameStates {
    Main
} //end GameStates
public delegate void OnStateChangeHandler();

public class GameManager : MonoSingleton<GameManager>
{

    public event OnStateChangeHandler OnStateChange;

    public bool isPlayerOne { get; set; }
    public int currentTurn { get; set; }

    public GameStates GameState { get; private set; }

    private void Start()
    {
        isPlayerOne = true;
    } //end Start

    /// <summary>
    /// This function sets the next gamestate and handles the event of changing states via the additive of the delegate.
    /// </summary>
    public void SetGameState(GameStates gameState)
    {
        this.GameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    } //end SetGameState

    public void NextTurn()
    {
        //This is to end the turn if 2 player game 
        isPlayerOne = !isPlayerOne;
    } //end NextTurn
} //end GameManager class
