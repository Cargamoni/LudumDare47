using UnityEngine;

public class Lamp : MonoBehaviour {

    public GameObject explotionPrefab;
    public float triggerRadius = 2f;

    public GameObject lightGo;
    public GameObject sparkGo;
    public Rigidbody lampRb;
    public LayerMask rayMask;

    void Update() {
        
        if (Physics.CheckSphere(transform.position, triggerRadius, rayMask.value)) {

            sparkGo.SetActive(true);
            lampRb.isKinematic = false;
            Instantiate(explotionPrefab, transform.position, Quaternion.identity);
            lightGo.SetActive(false);

            Player.instance.die();
            lampRb.AddExplosionForce(10f, Random.insideUnitSphere, 0.5f);

            Destroy(this);

        }

    }

}