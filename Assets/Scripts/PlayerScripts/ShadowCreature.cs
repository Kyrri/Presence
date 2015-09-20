using UnityEngine;
using System.Collections;

public class ShadowCreature : MonoBehaviour {
    public float health = 100;
    private PointCount pointcount;
	// Use this for initialization
    public void Start()
    {
        pointcount = GameObject.Find("Player").GetComponent <PointCount> ();
    }
    public void takeHealth()
    {
        health -= 10f;
        if (health <= 0)
        {
            killCreature();
        }
    }
	public void killCreature()
    {
        //stop moving + dying animation
        Destroy(gameObject);
        pointcount.addPoint();

    }
}
