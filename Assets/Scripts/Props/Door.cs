using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Action {

    public bool locked;
    public bool opened;

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

}