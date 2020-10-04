using UnityEngine;

public class Repear : MonoBehaviour{

    private Vector3 forwardPos;

    void Start() {
        forwardPos = transform.position + transform.up * -1.5f;
    }

    void Update(){

        transform.position = Vector3.MoveTowards(transform.position, forwardPos, Time.deltaTime * 10f);

        var dir = transform.position - Player.instance.transform.position;
        transform.forward = Vector3.up;
        float angle = Vector3.SignedAngle(transform.up, dir,Vector3.forward);
        
        transform.Rotate(transform.up, angle, Space.Self);
    }

}            