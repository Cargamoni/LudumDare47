using UnityEngine;
using UnityEngine.UI;

public class ActionText : MonoBehaviour {

    public static ActionText instance;
    public Text text;

    private void Awake() {
        instance = this;
    }

    public void setText(string value) {
        text.text = value;
    }

}