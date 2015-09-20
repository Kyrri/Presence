using UnityEngine;
using System.Collections;
using Pose = Thalmic.Myo.Pose;


public class flashAttack : MonoBehaviour
{
    public Light light;
    public int flashUses = 3;
    private float delay = 10;
    private bool flashAvail = true;
    float t = 0;
    TextMesh flashReady;
    ThalmicMyo thalmicMyo;
    public GameObject myo;

    void Start()
    {
        light.enabled = false;
        flashReady = GameObject.Find("Player/MainCamera/TrackingSpace/Flash").GetComponent<TextMesh>();
        myo = GameObject.Find("Myo");
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thalmicMyo.pose != Thalmic.Myo.Pose.FingersSpread)
        {
            endFlash();
        }
        if ((thalmicMyo.pose == Thalmic.Myo.Pose.FingersSpread) && flashAvail && flashUses > 0)
        {
            light.enabled = true;
            if (light.intensity < 1f)
            {
                light.intensity += 0.01f;
            }
            if (light.intensity >= 1f)
            {
                flashAvail = false;
                flashReady.text = "";
                Object[] shadowcreatures = FindObjectsOfType(typeof(ShadowCreature));
                for (int i = 0; i < shadowcreatures.Length; i++)
                {
                    ShadowCreature temp = (ShadowCreature)shadowcreatures[i];
                    temp.killCreature();
                }
                flashUses--;
                Invoke("endFlash", 1);            
            }
        }
        else if(!flashAvail && flashUses >0)
        {
            t += Time.deltaTime;
            if (t >= delay)
            {
                flashAvail = true;
                t = 0;
                flashReady.text = "Flash Ready";
            }
        }
    }
    void endFlash() 
    {
        light.intensity = 0;
        light.enabled = false;
    }
}
