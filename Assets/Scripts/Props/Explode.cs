using UnityEngine;

public class Explode : MonoBehaviour {

    public GameObject explotionPrefab;
    public float triggerRadius = 2f;

    public GameObject effect;
    public Rigidbody rb;
    public LayerMask rayMask;

    void Update() {
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < triggerRadius) {
            if (Physics.Linecast(transform.position, Player.instance.transform.position, rayMask)) {

                effect.SetActive(true);
                rb.isKinematic = false;
                Instantiate(explotionPrefab, transform.position, Quaternion.identity);

                Player.instance.die();
                rb.AddExplosionForce(10f, Random.insideUnitSphere, 0.5f);

                Destroy(this);

            }
        }
    }

}