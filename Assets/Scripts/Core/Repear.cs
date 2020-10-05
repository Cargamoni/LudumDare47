using UnityEngine;

public class Repear : MonoBehaviour{

    private Vector3 forwardPos;
    public AudioClip sound;

    void Start() {
        forwardPos = transform.position + transform.up * -2f;
    }

    void Update(){

        transform.position = Vector3.MoveTowards(transform.position, forwardPos, Time.deltaTime * 10f);

        var dir = transform.position - Player.instance.transform.position;
        transform.forward = Vector3.up;
        float angle = Vector3.SignedAngle(transform.up, dir,Vector3.forward);
        
        transform.Rotate(transform.up, angle, Space.Self);

        if(Vector3.Distance(transform.position, Player.instance.transform.position) < 1f) {
            AudioManager.instance.playSfx(sound);
            Player.instance.die();
        }

    }

}