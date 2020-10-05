using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour{

    public Fade fade;
    public static Player2 instance;
    public bool isDead;

    void Start() {
        instance = this;
    }

    public void die() {
        if (isDead) return;
        isDead = true;

        StartCoroutine(dieCoroutine());
    }

    private IEnumerator dieCoroutine() {
        fade.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;

        GameManager.currentState = GameStates.Playing;
        SceneManager.LoadScene("Play");

    }

}
