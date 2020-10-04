using UnityEngine;
using UnityEngine.UI;

public enum Screens {
    Main,
    Settings,
    InGame,
    About,
    End,
    Win,
    Lose
}

public class UIManager : MonoBehaviour {

    private int currentScreenIndex;
    public GameObject[] screens;
    public static UIManager instance;
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;

    private void Awake() {
        instance = this;
    }


    private void Start() {

        masterVolume.onValueChanged.AddListener(OnMasterVolumeChanged);
        musicVolume.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolume.onValueChanged.AddListener(OnSfxVolumeChanged);

        masterVolume.value = AudioManager.instance.getMasterVolume();
        musicVolume.value = AudioManager.instance.getMusicVolume();
        sfxVolume.value = AudioManager.instance.getSfxVolume();

    }

    public void ChangeScreen(int screen) {
        screens[currentScreenIndex].SetActive(false);
        screens[screen].SetActive(true);
        currentScreenIndex = screen;
    }

    public void OnMasterVolumeChanged(float value) {
        AudioManager.instance.setMasterVolume(value);
    }

    public void OnMusicVolumeChanged(float value) {
        AudioManager.instance.setMusicVolume(value);
    }

    public void OnSfxVolumeChanged(float value) {
        AudioManager.instance.setSfxVolume(value);
    }

}