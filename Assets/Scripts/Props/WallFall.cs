using UnityEngine;

public class WallFall : MonoBehaviour{

    public GameObject explotionPrefab;
    public float triggerRadius = 2f;

    public GameObject effect;
    public Rigidbody rb;
    public LayerMask rayMask;

    void Update() {
        if (Physics.CheckSphere(transform.position, triggerRadius, rayMask.value)) {

            if(effect != null) effect.SetActive(true);
            rb.isKinematic = false;
            Instantiate(explotionPrefab, transform.position, Quaternion.identity);

            Player.instance.die();
            rb.AddExplosionForce(10f, Random.insideUnitSphere, 0.5f);

            Destroy(this);

        }
    }

}
