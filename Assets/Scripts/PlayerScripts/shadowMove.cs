using UnityEngine;
using System.Collections;

public class shadowMove : MonoBehaviour {
    float speed;
    float swerveAmount = 0.5f;
    float swerveSpeed = 2.0f;
    private GameObject player;
    PlayerLife life;
    public int moveType;

    void Start()
    {
        speed = 7.0f + (Time.time / 30);
        player = GameObject.Find("Player/MainCamera");
        moveType = Random.Range(0, 3);
        life = player.GetComponent<PlayerLife>();
    }
	void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) < 35)
        {
            moveType = 0;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            life.damage();
        }
        else
        {
            switch (moveType)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    break;
                case 1:
                    Vector3 delta = player.transform.position - transform.position;
                    Vector3 deltaP = new Vector3(-delta.y, 0, delta.x);
                    Vector3 offset = deltaP * swerveAmount / Mathf.Sin(Time.time * swerveSpeed);
                    Vector3 swerveTarget = player.transform.position + deltaP;
                    transform.position = Vector3.MoveTowards(transform.position, swerveTarget, speed * Time.deltaTime);
                    break;
                case 2:
                    delta = player.transform.position - transform.position;
                    deltaP = new Vector3(delta.y, 0, -delta.x);
                    offset = deltaP * swerveAmount * Mathf.Sin(Time.time * swerveSpeed);
                    swerveTarget = player.transform.position + deltaP;
                    transform.position = Vector3.MoveTowards(transform.position, swerveTarget, speed * Time.deltaTime);
                    break;
            }
        }
	}
}
