using UnityEngine;

public class Explode : MonoBehaviour {

    public GameObject explotionPrefab;
    public float triggerRadius = 2f;

    public GameObject lightGo;
    public GameObject sparkGo;
    public Rigidbody lampRb;

    void Update() {

        if (Vector3.Distance(transform.position, Player.instance.transform.position) < triggerRadius) {



            sparkGo.SetActive(true);
            lampRb.isKinematic = false;
            Instantiate(explotionPrefab, transform.position, Quaternion.identity);

            Player.instance.die();
            lampRb.AddExplosionForce(10f, Random.insideUnitSphere, 0.5f);

            Destroy(this);

        }

    }

}