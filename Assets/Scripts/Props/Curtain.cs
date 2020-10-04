using UnityEngine;

public class Curtain : Action {

    public bool locked;
    public bool opened;

    public AudioClip lockedSound;
    public AudioClip normalSound;
    private float scale;

    public void Start() {
        scale = transform.localScale.x;
    }

    public override AudioClip getSound() {
        return locked ? lockedSound : normalSound;
    }

    public override string getText() {
        return opened ? "Close" : "Open";
    }

    public override void invoke() {
        opened = !opened;
        transform.localScale = new Vector3(
            opened ? scale * 0.25f : scale,
            transform.localScale.y,
            transform.localScale.z
        );
    }

}