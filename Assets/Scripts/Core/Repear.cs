using UnityEngine;

public class Repear : MonoBehaviour{

    private Vector3 forwardPos;

    void Start() {
        forwardPos = transform.position + transform.up * -1.5f;
    }

    void Update(){

        transform.position = Vector3.MoveTowards(transform.position, forwardPos, Time.deltaTime * 10f);

        var dir = transform.position - Player.instance.transform.position;
        dir.z = 0;
        dir.y = -dir.y;
        transform.rotation = Quaternion.LookRotation( transform.TransformDirection(dir));

    }

}
