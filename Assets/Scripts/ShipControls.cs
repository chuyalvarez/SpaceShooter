using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    private float leftDivisor,rightDivisor,screenWidth;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private GameObject ammo;
    [SerializeField]
    private GameObject gameController;
    private bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        leftDivisor = screenWidth / 5 * 2;
        rightDivisor = screenWidth / 5 * 3;

    }

// Update is called once per frame
void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x>0 && Input.mousePosition.x < leftDivisor)
            {
                if (transform.position.z < 4)
                {
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
                
            }
            else if (Input.mousePosition.x > rightDivisor && Input.mousePosition.x < screenWidth)
            {
                if (transform.position.z > -4)
                {
                    transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                }
            }

            if (!shooting)
            {
                StartCoroutine(shoot());
            }
        }

    }

    public void takeDamage()
    {
        gameController.GetComponent<GameController>().loseLife();
    }

    IEnumerator shoot()
    {
        shooting = true;
        Instantiate(ammo, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        shooting = false;
    }
}
