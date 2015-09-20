using UnityEngine;
using System.Collections;
using Pose = Thalmic.Myo.Pose;

public class destroyShadow : MonoBehaviour {
    Ray shootRay;
    RaycastHit shootHit;
    public float range;
    flashlight light;
    ThalmicMyo thalmicMyo;
    public GameObject myo;

    void Start()
    {
        light = GetComponent<flashlight>();
        myo = GameObject.Find("Myo");
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }
	void Update () {
        if (thalmicMyo.pose == Thalmic.Myo.Pose.Fist)
        {
            if (light.battery > 0)
            {
                Shoot();
            }
        }
	}
    void Shoot()
    {
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast(shootRay, out shootHit, range))
        {
            ShadowCreature shadowCreature = shootHit.collider.GetComponent<ShadowCreature>();
            if(shadowCreature!= null)
            {
                shadowCreature.takeHealth();
            }
        }
    }
}
