using UnityEngine;

public class FallTrigger : MonoBehaviour {

    public Rigidbody target;
    public AudioClip fallSound;

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject != target.gameObject) {
            target.isKinematic = false;
            AudioManager.instance.playSfx(fallSound);
            Destroy(gameObject);
        }
    }

}