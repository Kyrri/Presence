using UnityEngine;
using System.Collections;

public class ShadowCreature : MonoBehaviour {
    public float health = 100;
	// Use this for initialization
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

    }
}
