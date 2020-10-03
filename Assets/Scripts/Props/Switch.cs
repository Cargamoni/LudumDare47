using UnityEngine;

public class Switch : Action {

    public bool on;
    public GameObject[] targets;
    public AudioClip sound;

    public override AudioClip getSound() {
        return sound;
    }

    public override string getText() {
        return on ? "Turn Off" : "Turn On";
    }

    public override void invoke() {
        on = !on;
        if (targets != null) {
            foreach (var i in targets) {
                i.SetActive(!i.activeSelf);
            }
        }
    }

}