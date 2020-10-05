using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Force : MonoBehaviour {

    public float triggerRadius = 2f;

    private void Update() {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < triggerRadius) {
            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Random.Range(-100f, +100f), 200f, Random.Range(-100f, +100f)));
            Destroy(this);
        }
    }

}