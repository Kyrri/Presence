using UnityEngine;
using System.Collections;
using Pose = Thalmic.Myo.Pose;

public class flashlight : MonoBehaviour {
    public Light light;
    public float battery = 100;
    public bool batteryDead = false;
    TextMesh batteryLeft;
    ThalmicMyo thalmicMyo;
    public GameObject myo;

    void Start ()
    {
       batteryLeft = GameObject.Find("Player/MainCamera/TrackingSpace/Battery").GetComponent<TextMesh>();
       myo = GameObject.Find("Myo");
       thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }
	void Update () {
        if (thalmicMyo.pose == Thalmic.Myo.Pose.Fist)
        {
            if (battery > 0 && !batteryDead)
            {
                battery-=0.1f;
                batteryUpdate();
            }
            else
            {
                light.enabled = false;
                batteryDead = true;
            }
            if (!light.enabled && !batteryDead)
            {
                light.enabled = true;
            }
        }
        else
        {
            if (light.enabled && !batteryDead)
            {
                light.enabled = false;
            }
        }
        if(thalmicMyo.pose == Pose.DoubleTap)
        {
            if (battery < 100)
            {
                battery += 0.2f;
                batteryUpdate();
            }
            if(battery > 25)
            {
                batteryDead = false;
            }
        }
	}
   void batteryUpdate()
   {
       batteryLeft.text = "Battery: " + Mathf.FloorToInt(battery)+"%";
   }
}
