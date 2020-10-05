using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    private void Update() {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < 3f) {
            GameManager.currentState = GameStates.Playing;
            SceneManager.LoadScene("Final");
        }
    }

}