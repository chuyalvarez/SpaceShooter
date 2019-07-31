using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    [SerializeField]
    private Transform asteroidSpawnPoint;
    private bool spawning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning)
        {
            StartCoroutine(spawnAsteroids());
        }
    }

    IEnumerator spawnAsteroids()
    {
        spawning = true;
        Instantiate(asteroid,new Vector3(asteroidSpawnPoint.position.x, asteroidSpawnPoint.position.y , (Random.Range(-50,50)/10f) + asteroidSpawnPoint.position.z) ,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        spawning = false;
    }
}
