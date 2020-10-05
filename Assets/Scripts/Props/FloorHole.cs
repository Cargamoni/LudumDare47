using System.Collections;
using UnityEngine;

public class FloorHole : MonoBehaviour {

    public GameObject effectPrefab;
    private bool falling;

    private IEnumerator OnTriggerEnter(Collider other) {

        if (falling) yield break;
        falling = true;

        Instantiate(effectPrefab, transform.position, Quaternion.identity);

        if (other.CompareTag("Player")) {
            Player.instance.die();
        }

        while (transform.position.y < 1f ) {
            transform.position += new Vector3(0f, -16f * Time.deltaTime, 0f);
            yield return null;
        }


    }

}