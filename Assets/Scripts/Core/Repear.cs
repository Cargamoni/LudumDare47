using UnityEngine;

public class Repear : MonoBehaviour{

    void Update(){
        var dir = transform.position - Player.instance.transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

}
