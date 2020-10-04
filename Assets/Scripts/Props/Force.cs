using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Force : MonoBehaviour{

    public float triggerRadius = 2f;
    public GameObject effect;
    public LayerMask layerMask;

    private void Update() {
        if (Physics.CheckSphere(transform.position, triggerRadius, layerMask.value)) {
            if (effect != null) Instantiate(effect, transform.position, Quaternion.identity);
            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Random.Range(-100f, +100f), 500f, Random.Range(-100f, +100f)));
            Destroy(this);
        }
    }

}
