using System.Collections;
using UnityEngine;

public class Axe : MonoBehaviour {

    public AudioClip fallSound;
    public AudioClip crashSound;
    public AudioClip killSound;
    private bool falling;
    private bool fell;

    private void OnTriggerEnter(Collider other) {

        if (falling) return;

        if (other.CompareTag("Player") || other.CompareTag("Pickup")) {
            falling = true;

            AudioManager.instance.playSfx(fallSound);
            GetComponent<Rigidbody>().isKinematic = false;

        }

    }

    private void OnCollisionEnter(Collision collision) {

        if (!collision.gameObject.CompareTag("Player")) {
            AudioManager.instance.playSfx(crashSound);
        }

        if (fell) return;
        fell = true;

        if (collision.gameObject.CompareTag("Player")) {
            AudioManager.instance.playSfx(killSound);
        }

    }

}