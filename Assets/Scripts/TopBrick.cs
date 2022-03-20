using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopBrick : MonoBehaviour
{
    public GameObject[] EndUI;
    GameManager gM;
    bool gameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive && Input.GetKeyDown(KeyCode.Space) && gM.credits > 0)
        {
            gM.credits--;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(gameActive)
        {
            float score = gM.scoreTotal;
            int bricks = gM.bricksRemoved;
            Debug.Log("Towers fallen");
            EndUI[0].SetActive(false);
            EndUI[1].SetActive(true);

            if (bricks >= 18)
            {
                EndUI[3].GetComponent<Text>().text = "BIG FUCKING TICKETS BONUS"; //Name WIP
                EndUI[2].GetComponent<Text>().text = (100 + score).ToString();
            }
            else
            {
                EndUI[3].GetComponent<Text>().text = (18 - bricks).ToString() + " Bricks away from the big bonus";
                EndUI[2].GetComponent<Text>().text = (score).ToString();
            }
            if (gM.credits > 0)
            {
                EndUI[4].GetComponent<Text>().text = "Press fire to play again!";
            }
            else
            {
                EndUI[4].GetComponent<Text>().text = "Press C to insert credit, then fire to play again";
            }
            gameActive = false;
            Debug.Log(bricks);
        }
    }
        
}
