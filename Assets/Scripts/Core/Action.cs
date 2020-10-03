using UnityEngine;
using UnityEngine.Events;

public class Action : MonoBehaviour {

    public virtual AudioClip getSound() {
        return null;
    }

    public virtual string getText() {
        return "kullan";
    }

    public virtual void invoke() {
    }

}