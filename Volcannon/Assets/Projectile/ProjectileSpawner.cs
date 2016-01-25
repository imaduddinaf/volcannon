using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour 
{
    // projectile
    private int projectileIndex;
    private GameObject[] projectiles;
    public GameObject square;

    // spawn time
    private float spawnTime = 5.0f;
    private float spawnTimeCounter;

	// Use this for initialization
	void Start () 
    {
        // projectile init
        projectileIndex = 0; // di implementasinya, random
        projectiles = new GameObject[1];
        projectiles[0] = square;

        //spawn time init
        spawnTime = 2.0f;
        spawnTimeCounter = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("counter : " + spawnTimeCounter);
        if (spawnTimeCounter > spawnTime)
        {
            Debug.Log("spawn");
            Instantiate(projectiles[0]);
            spawnTimeCounter = 0.0f;
        }
        spawnTimeCounter += Time.deltaTime;
	}
}
