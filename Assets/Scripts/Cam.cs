using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour {

    private static Cam instance;

    private void Awake() {
        instance = this;
    }

}