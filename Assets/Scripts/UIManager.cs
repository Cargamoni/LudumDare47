using UnityEngine;

public enum Screens {
    Main,
    Settings,
    InGame,
    About,
    Win,
    Lose
}

public class UIManager : MonoBehaviour {

    private int currentScreenIndex;
    public GameObject[] screens;

    public void ChangeScreen(int screen) {
        screens[currentScreenIndex].SetActive(false);
        screens[screen].SetActive(true);
        currentScreenIndex = screen;
    }

}