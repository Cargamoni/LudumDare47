using System.Collections;
using UnityEngine;

public class FloorHole : MonoBehaviour {

    public AudioClip fallSound;
    private bool falling;

    private IEnumerator OnTriggerEnter(Collider other) {

        if (falling) yield break;
        falling = true;
        AudioManager.instance.playSfx(fallSound);

        //yield return new WaitForSeconds(0.5f);
        while (transform.position.y < 1f ) {
            transform.position += new Vector3(0f, -16f * Time.deltaTime, 0f);
            yield return null;
        }
    }

}