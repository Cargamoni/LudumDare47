using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public Color start;
    public Color end;
    public float duration;

    private IEnumerator Start() {
        var rawImage = GetComponent<Image>();
        var t = 0f;
        while (true) {
            t += Time.deltaTime;
            rawImage.color = Color.Lerp(start, end, t / duration);
            yield return null;
        }
    }

}