using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {
    public float health = 100;
    TextMesh healthLeft;
    void Start()
    {
       healthLeft = GameObject.Find("Player/MainCamera/TrackingSpace/Health").GetComponent<TextMesh>();
    }
    public void damage()
    {
        if (health <= 0)
        {
            gameOver();
        }
        health -= 0.5f;
        healthLeft.text = "Health: " + Mathf.FloorToInt(health);
    }
    void gameOver()
    {
        Application.LoadLevel("GameOver");
    }
}
