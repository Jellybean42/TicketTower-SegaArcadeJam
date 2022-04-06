using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopBrick : MonoBehaviour
{
    public GameObject[] EndUI;
    GameManager gM;
    Statistics _statistics;
    bool gameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        _statistics = FindObjectOfType<Statistics>();
        _statistics.GameStarted();
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive && Input.GetKeyDown(KeyCode.Space) && _statistics.credits > 0)
        {
            gM.CoinDown();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(gameActive)
        {
            int score = gM.scoreTotal;
            int bricks = gM.bricksRemoved;
            Debug.Log("Towers fallen");
            EndUI[0].SetActive(false);
            EndUI[1].SetActive(true);

            if(gM.red >= 5)
            {
                score += 15;
            }
            if (gM.blue >= 5)
            {
                score += 10;
            }
            if (gM.green >= 5)
            {
                score += 5;
            }
            if(gM.red+gM.blue+gM.green == 15)
            {
                score += 30;
            }


            EndUI[3].GetComponent<Text>().text = gM.green + "/5 Green Ghosts \n"+ gM.blue + "/5 Blue Ghosts \n"+ gM.red + "/5 Red Ghosts";
            EndUI[2].GetComponent<Text>().text = (score).ToString();

            if (_statistics.credits > 0)
            {
                EndUI[4].GetComponent<Text>().text = "Press fire to play again!";
            }
            else
            {
                EndUI[4].GetComponent<Text>().text = "Press C to insert credit, then fire to play again";
            }
            gameActive = false;
            _statistics.GameComplete(score);
            Debug.Log(bricks);
        }
    }
        
}
