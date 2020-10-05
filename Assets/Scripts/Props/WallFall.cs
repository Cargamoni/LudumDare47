using UnityEngine;

public class WallFall : MonoBehaviour{

    public GameObject explotionPrefab;
    public float triggerRadius = 2f;

    public GameObject effect;
    public Rigidbody rb;
    public LayerMask rayMask;

    void Update() {
        if (Physics.CheckSphere(transform.position, triggerRadius * 0.7f, rayMask.value)) {

            if(effect != null) effect.SetActive(true);
            rb.isKinematic = false;

            Instantiate(explotionPrefab, transform.position, Quaternion.identity);
            rb.AddForce(new Vector3(Random.Range(-200f, +200f), 300f, Random.Range(-200f, +200f)));

            if (Vector3.Distance(transform.position, Player.instance.transform.position) <= triggerRadius) {
                Player.instance.die();
            }

            Destroy(this);

        }
    }

}
