using UnityEngine;

public class Door : Action {

    public bool locked;
    public bool opened;
    public GameObject repear;

    public AudioClip lockedSound;
    public AudioClip normalSound;
    private float angle;

    public void Start() {
        angle = transform.eulerAngles.y;
    }

    public override AudioClip getSound() {
        return locked ? lockedSound : normalSound;
    }

    public override string getText() {
        return opened ? "Close" : "Open";
    }

    public override void invoke() {
        opened = !opened;
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x, 
            angle + (opened ? -90f : 0f),
            transform.eulerAngles.z
        );
    }

    private void Update() {
        if(repear != null && !repear.activeSelf && Vector3.Distance(transform.position, Player.instance.transform.position) < 2f) {
            if (!opened) invoke();
            repear.SetActive(true);
        }
    }

}