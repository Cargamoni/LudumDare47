using UnityEngine;

public class ReaperTruck : MonoBehaviour {

    public float speed;

    public float triggerDistance = 150f;
    public float slowMotionDistance = 50f;
    public float dieDistance = 5f;

    public Transform player;

    private void Update() {
        var distance = Vector3.Distance(transform.position, player.position);
        if (distance < triggerDistance) { 

            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPos);

            Time.timeScale = Mathf.Clamp01(distance / slowMotionDistance);

            if(distance < dieDistance) {
                Player2.instance.die();
                return;
            }

            var pos = transform.position;
            pos += transform.forward * speed * Time.unscaledDeltaTime;
            transform.position = pos;

        }
    }

}