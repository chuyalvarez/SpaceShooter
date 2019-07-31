using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    [SerializeField]
    private Transform asteroidSpawnPoint;
    private float hScore,totalScore;
    private bool spawning,gameover;
    private int life = 3;
    [SerializeField]
    private Text lifeDisplay;
    [SerializeField]
    private Text scoreDisplay;
    [SerializeField]
    private Text gameoverText;
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private Button mainMenu;
    [SerializeField]
    private GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        lifeDisplay.text = "Life: " + life + "/3";
        PlayerPrefs.SetFloat("Score", 0);
        mainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            if (!spawning)
            {
                StartCoroutine(spawnAsteroids());
            }

            scoreDisplay.text = "Score: " + PlayerPrefs.GetFloat("Score");
        }
    }

    public void loseLife()
    {
        life--;
        lifeDisplay.text = "Life: " + life + "/3";
        if (life <= 0)
        {
            endGame();
        }
    }


    private void endGame()
    {
        ship.SetActive(false);
        gameover = true;
        gameoverText.text = "YOU LOSE!";
        

        hScore = PlayerPrefs.GetFloat("Highscore",0);
        totalScore = PlayerPrefs.GetFloat("Score");
        if (totalScore > hScore)
        {
            PlayerPrefs.SetFloat("Highscore",totalScore);
            highscoreText.text = "New Highscore! " + totalScore;

        }
        else
        {
            highscoreText.text = "Highscore: "+hScore;
        }
        mainMenu.gameObject.SetActive(true);
        
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator spawnAsteroids()
    {
        spawning = true;
        Instantiate(asteroid,new Vector3(asteroidSpawnPoint.position.x, asteroidSpawnPoint.position.y , (Random.Range(-50,50)/10f) + asteroidSpawnPoint.position.z) ,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        spawning = false;
    }
}
