using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour {

    public static Death instance;
    public bool isDeath;

    private void Start() {
        instance = this;
        Time.timeScale = 1f;
    }

    public void tekrar() {
        SceneManager.LoadScene("Play");
    }

    public void menu() {
        SceneManager.LoadScene("Menu");
    }

    public void show() {
        isDeath = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        foreach (var i in GetComponents<AudioSource>()) {
            i.Play();
        }
        StartCoroutine(showCoroutine());
    }

    private IEnumerator showCoroutine() {

        //butonları göster
        transform.GetChild(0).gameObject.SetActive(true);

        //fade
        var image = GetComponent<RawImage>();
        var elapsed = 0f;
        var duration = 1.5f;
        while (elapsed < duration) {
            image.color = new Color(0.1f, 0f, 0f, Mathf.Lerp(0f, 0.7f, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }


    }

}