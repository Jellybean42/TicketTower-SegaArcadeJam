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
    public Text statsText;
    public int red = 0;
    public int blue = 0;
    public int green = 0;
    public GameObject[] EndUI;
    public bool gameActive = false;
    Statistics _statistics;
    // Start is called before the first frame update
    void Start()
    {
        statsText = FindObjectsOfType<Text>()[0];
        scoreText = FindObjectsOfType<Text>()[1];
        _statistics = FindObjectOfType<Statistics>();
        _statistics.GameStarted();
    }

    // Update is called once per frame
    void Update()
    {
        statsText.text = "";
        scoreText.text = "Tickets: " + scoreTotal;
        creditsText.text = "Credits: " + _statistics.credits;

        if (Input.GetKeyDown(KeyCode.C))
        {
            _statistics.AddCredits();
        } 
        
        if (Input.GetKey(KeyCode.Period))
        {
            statsText.text = "Total Run Time: " + _statistics.totalRunTime.ToString("0") + " seconds\r\n" +
                             "Total Credits Taken: " + _statistics.totalCreditsTaken + "\r\n" +
                             "Total Plays: " + _statistics.totalPlays + "\r\n" +
                             "Average Game Time: " + _statistics.averagePlayTime.ToString("0.0") + " seconds\r\n" +
                             "Total Tickets Paid: " + _statistics.totalTicketsPaid + "\r\n" +
                             "Lowest Ticket Payout: " + _statistics.lowestTicketPayout + "\r\n" +
                             "Highest Ticket Payout: " + _statistics.highestTicketPayout + "\r\n";
        }

        if (!gameActive && Input.GetKeyDown(KeyCode.Space) && _statistics.credits > 0)
        {
            _statistics.RemoveCredits();
            scoreTotal = 0;
            SceneManager.LoadScene(0);
            gameActive = true;
        }
    }

    public void IncreaseScore(int score, int familly)
    {
        bricksRemoved++;
        scoreTotal += score;
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
                score += 15;
            }
            if (blue >= 5)
            {
                score += 10;
            }
            if (green >= 5)
            {
                score += 5;
            }
            if (red + blue + green == 15)
            {
                score += 30;
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
