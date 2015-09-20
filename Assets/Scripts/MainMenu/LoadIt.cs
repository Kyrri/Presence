using UnityEngine;
using System.Collections;

public class LoadIt : MonoBehaviour {

    // Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            Application.LoadLevel("ShadowRoom");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Application.Quit();
        }
    }
}
