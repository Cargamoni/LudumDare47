using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explode : MonoBehaviour{

    public float triggerRadius = 2f;
    public GameObject effect;

    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Player") || other.CompareTag("Pickup")) { 

            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Random.Range(-200f, +200f), 300f, Random.Range(-200f, +200f)));

            if (effect != null) {
                Instantiate(effect, transform.position, Quaternion.identity);
            }

            if (other.CompareTag("Player")) {
                Player.instance.die();
            }

            Destroy(this);

        }

    }

}
