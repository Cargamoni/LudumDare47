using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates {
    Menu,
    Playing,
    Win,
    Lose
}

public class GameManager : MonoBehaviour {

    public static GameManager main;
    public static GameStates currentState;
    public bool m_LockCursor;

    private void Awake() {
        main = this;
    }

    private void Start() {
        ChangeGameState((int)currentState);
    }

    public void ChangeGameState(int state) {
        currentState = (GameStates)state;
        switch ((GameStates)state) {
            case GameStates.Menu:
                ToggleCursor(false);
                UIManager.instance.ChangeScreen((int)Screens.Main);
                break;
            case GameStates.Playing:
                ToggleCursor(true);
                UIManager.instance.ChangeScreen((int)Screens.InGame);
                break;
            case GameStates.Win:
                UIManager.instance.ChangeScreen((int)Screens.Win);
                break;
            case GameStates.Lose:
                UIManager.instance.ChangeScreen((int)Screens.Lose);
                break;
            default:
                break;
        }
    }

    private void ToggleCursor(bool locked) {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
        m_LockCursor = locked;
    }

    public static bool IsOnMenu() {
        return GameManager.currentState == GameStates.Menu;
    }

    public static bool IsPlaying() {
        return GameManager.currentState == GameStates.Playing;
    }

    public static bool IsWin() {
        return GameManager.currentState == GameStates.Win;
    }

    public static bool IsFail() {
        return GameManager.currentState == GameStates.Lose;
    }

}
