using UnityEngine;

public class Car : MonoBehaviour{

    public float speed = -50f;
    public float len = 500f;

    void Update() {
        
        if (Player2.instance.isDead) return;

        var pos = transform.position;
        pos += transform.forward * speed * Time.deltaTime;
        if(pos.z > len) {
            pos.z = -len;
        }
        else if (pos.z < -len) {
            pos.z = +len;
        }
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Player2.instance.die();
        }
    }

}
