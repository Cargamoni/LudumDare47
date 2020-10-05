using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour{

    public Fade fade;
    public static Player2 instance;
    public bool isDead;
    public AudioClip dieSound;

    void Start() {
        instance = this;
    }

    public void die() {
        if (isDead) return;
        isDead = true;
        AudioManager.instance.playSfx(dieSound);
        StartCoroutine(dieCoroutine());
    }

    private IEnumerator dieCoroutine() {
        fade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;

        GameManager.currentState = GameStates.Playing;
        SceneManager.LoadScene("Play");

    }

}
