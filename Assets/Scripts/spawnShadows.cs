using UnityEngine;
using System.Collections;

public class spawnShadows : MonoBehaviour {
	private float spawnDelay = 20.0f;
    private float lowerDelay = 20.0f;
    float t = 0;
    float tL = 0;
    bool spawnShadow = true;
    public Transform shadow;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player/MainCamera");
    }
    void Update()
    {
        tL += Time.deltaTime;
        if (tL > lowerDelay && spawnDelay>1)
        {
            spawnDelay -= 0.3f;
            tL = 0;
        }
        if (spawnShadow)
        {
            float nextX;
            float nextY = Random.Range(5, 100);
            float nextZ;
            if (player.transform.position.x < 0)
            {
                nextX = Random.Range(50, 180);
            }
            else
            {
                nextX = Random.Range(-50, -180);
            }
            if (player.transform.position.z < 0)
            {
                nextZ = Random.Range(50, 240);
            }
            else
            {
                nextZ = Random.Range(-50, -240);
            }
            Instantiate(shadow, new Vector3(nextX, nextY, nextZ), Quaternion.identity);

            spawnShadow = false;
        }
        else
        {
            t += Time.deltaTime;
            if (t >= spawnDelay)
            {
                spawnShadow = true;
                t = 0;
            }
        }
    }
}
