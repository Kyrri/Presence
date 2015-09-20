using UnityEngine;
using System.Collections;

public class DarkenWorld : MonoBehaviour {
    public Light light;
    private float delay = 30;
    float t = 0;

	// Update is called once per frame
	void Update () {
        if (light.intensity > 0.1f)
        {
            t += Time.deltaTime;
            if (t >= delay)
            {
                darkenthis();
                t = 0;
            }
        }
        else
        {
            light.enabled = false;
        }
    }
    void darkenthis()
    {
        light.intensity -= 0.1f;
    }
}
