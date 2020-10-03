using UnityEngine;

public class CollisionSound : MonoBehaviour {

    public AudioClip bounceSound;

    [Range(0f, 1f)]
    public float scale = 0.5f;

    private void OnCollisionEnter(Collision collision) {
        var value = Mathf.Clamp01((collision.relativeVelocity.magnitude * 10f) * scale);
        AudioManager.instance.playSfx(bounceSound, transform.position, value);
    }

}