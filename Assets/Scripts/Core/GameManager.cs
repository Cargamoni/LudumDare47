using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    Menu,
    Playing,
    Win,
    Lose
}

public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public GameStates currentState;
    public bool m_LockCursor;

    void Awake()
    {
        main = this;
    }
    private void Start()
    {
        ChangeGameState((int)GameStates.Menu);
    }
    public void ChangeGameState(int state)
    {
        currentState = (GameStates)state;
        switch ((GameStates)state)
        {
            case GameStates.Menu:
                ToggleCursor();
                UIManager.instance.ChangeScreen((int)Screens.Main);
                break;
            case GameStates.Playing:
                Debug.Log(m_LockCursor);
                ToggleCursor();
                Debug.Log(m_LockCursor);
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

    private void ToggleCursor()
    {
        Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !m_LockCursor;
        m_LockCursor = !m_LockCursor;
    }

    public static bool IsOnMenu()
    {
        return GameManager.main.currentState == GameStates.Menu;
    }

    public static bool IsPlaying()
    {
        return GameManager.main.currentState == GameStates.Playing;
    }

    public static bool IsWin()
    {
        return GameManager.main.currentState == GameStates.Win;
    }

    public static bool IsFail()
    {
        return GameManager.main.currentState == GameStates.Lose;
    }
}
