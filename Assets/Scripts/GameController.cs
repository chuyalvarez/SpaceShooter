using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    [SerializeField]
    private Transform asteroidSpawnPoint;
    private bool spawning;
    private int life = 3;
    [SerializeField]
    private Text lifeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        lifeDisplay.text = "Life: " + life + "/3";
    }

    // Update is called once per frame
    void Update()
    {

        if (!spawning)
        {
            StartCoroutine(spawnAsteroids());
        }
    }

    public void loseLife()
    {
        life--;
        lifeDisplay.text = "Life: " + life + "/3";
    }

    IEnumerator spawnAsteroids()
    {
        spawning = true;
        Instantiate(asteroid,new Vector3(asteroidSpawnPoint.position.x, asteroidSpawnPoint.position.y , (Random.Range(-50,50)/10f) + asteroidSpawnPoint.position.z) ,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        spawning = false;
    }
}
