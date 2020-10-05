using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Force : MonoBehaviour{

    public float triggerRadius = 2f;
    public bool explotion;
    public GameObject effect;
    public LayerMask layerMask;

    private void Update() {
        if (Physics.CheckSphere(transform.position, triggerRadius, layerMask.value)) {

            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Random.Range(-200f, +200f), 300f, Random.Range(-200f, +200f)));

            if (effect != null) {
                Instantiate(effect, transform.position, Quaternion.identity);
            }

            if (explotion) {
                Player.instance.die();
            }

            Destroy(this);

        }
    }

}
