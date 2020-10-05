using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour {

    private IEnumerator Start() {

        yield return new WaitForSeconds(5f);

        GameManager.currentState = GameStates.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}