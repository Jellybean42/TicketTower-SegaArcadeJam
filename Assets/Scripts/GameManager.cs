using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int bricksRemoved = 0;
    public int credits = 0;
    public int scoreTotal = 0;
    public Text scoreText;
    public Text creditsText;
    public int red = 0;
    public int blue = 0;
    public int green = 0;
    public GameObject[] EndUI;
    public GameObject OptionsUI;
    bool options = false;
    public bool gameActive = true;
    int blockFactor;
    int bonusFactor;
    float endTimer;
    Statistics _statistics;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();
        _statistics = FindObjectOfType<Statistics>();
        _statistics.GameStarted();
        blockFactor = (int)PlayerPrefs.GetFloat("block_factor");
        bonusFactor = (int)PlayerPrefs.GetFloat("bonus_factor");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Tickets: " + scoreTotal;
        creditsText.text = "Credits: " + _statistics.credits;
        endTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C))
        {
            _statistics.AddCredits();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            options = !options;
            OptionsUI.SetActive(options);

            if(!options)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (!gameActive && Input.GetKeyDown(KeyCode.Space) && _statistics.credits > 0)
        {
            _statistics.RemoveCredits();
            scoreTotal = 0;
            SceneManager.LoadScene(1);
            gameActive = true;
        }

        if (endTimer <= 0 && credits <= 0 && !gameActive)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void IncreaseScore(int score, int familly)
    {
        bricksRemoved++;
        scoreTotal += score * blockFactor;
        if(familly == 0)
        {
            red++;
        }
        if (familly == 1)
        {
            green++;
        }
        if (familly == 2)
        {
            blue++;
        }

        
    }

    public void EndGame()
    {
        endTimer = 15;
        if (gameActive)
        {
            gameActive = false;
            int score = scoreTotal;
            int bricks = bricksRemoved;
            Debug.Log("Towers fallen");
            EndUI[0].SetActive(false);
            EndUI[1].SetActive(true);

            if (red >= 5)
            {
                score += 15*bonusFactor;
            }
            if (blue >= 5)
            {
                score += 10 * bonusFactor;
            }
            if (green >= 5)
            {
                score += 5 * bonusFactor;
            }
            if (red + blue + green == 15)
            {
                score += 30 * bonusFactor;
            }


            EndUI[3].GetComponent<Text>().text = green + "/5 Green Ghosts \n" + blue + "/5 Blue Ghosts \n" + red + "/5 Red Ghosts";
            EndUI[2].GetComponent<Text>().text = (score).ToString();

            if (credits > 0)
            {
                EndUI[4].GetComponent<Text>().text = "Press fire to play again!";
            }
            else
            {
                EndUI[4].GetComponent<Text>().text = "Press C to insert credit, then fire to play again";
            }
            gameActive = false;
            _statistics.GameComplete(score);
        }

    }
}
