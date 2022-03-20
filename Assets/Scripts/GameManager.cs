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
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreTotal;
        creditsText.text = "Credits: " + credits;
        if (Input.GetKeyDown(KeyCode.C))
        {
            CoinUp();
        }
    }

    public void IncreaseScore(float score)
    {
        bricksRemoved++;
        scoreTotal += score;
    }

    public void CoinUp()
    {
        credits++;
    }
}
