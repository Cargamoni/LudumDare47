using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalManager : MonoBehaviour {

    public static SignalManager instance;

    private Dictionary<string, UnityAction> dictionary = new Dictionary<string, UnityAction>();

    private void Awake() {
        instance = this;
    }

    public void listen(string name, UnityAction callback) {
        if (dictionary.TryGetValue(name, out UnityAction c)) {
            c += callback;
        }
    }

    public void stopListen(string name, UnityAction callback) {
        if (dictionary.TryGetValue(name, out UnityAction c)) {
            c -= callback;
        }
    }

    public void signal(string name) {
        if (dictionary.TryGetValue(name, out UnityAction c)) {
            c();
        }
    }

}