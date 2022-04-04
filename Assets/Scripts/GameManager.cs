using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int bricksRemoved = 0;
    public int credits = 0;
    public float scoreTotal = 0;
    public Text scoreText;
    public Text creditsText;
    public int red = 0;
    public int blue = 0;
    public int green = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Tickets: " + scoreTotal;
        creditsText.text = "Credits: " + credits;
        if (Input.GetKeyDown(KeyCode.C))
        {
            CoinUp();
        }
    }

    public void IncreaseScore(float score, int familly)
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

    public void CoinUp()
    {
        credits++;
    }
}
