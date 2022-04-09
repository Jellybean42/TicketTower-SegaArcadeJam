using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataout : MonoBehaviour
{
    private const string DataVersionPref = "data_version";
    private const int DataVersion = 1;
    private const string CreditsPref = "credits";
    private const string TotalTimePref = "total_time";
    private const string TotalCreditsPref = "total_credits";
    private const string TotalPlaysPref = "total_plays";
    private const string AverageTimePref = "average_time";
    private const string TotalTicketsPref = "total_tickets";
    private const string LowestTicketPayoutPref = "lowest_ticket_payout";
    private const string HighestTicketPayoutPref = "highest_ticket_payout";

    public int credits;
    public float totalRunTime;
    public int totalCreditsTaken;
    public int totalPlays;
    public float averagePlayTime;
    public int totalTicketsPaid;
    public int lowestTicketPayout = -1;
    public int highestTicketPayout = -1;

    public Text dataText;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(DataVersionPref) && PlayerPrefs.GetInt(DataVersionPref) == DataVersion)
        {
            credits = PlayerPrefs.GetInt(CreditsPref);
            totalRunTime = PlayerPrefs.GetFloat(TotalTimePref);
            totalCreditsTaken = PlayerPrefs.GetInt(TotalCreditsPref);
            totalPlays = PlayerPrefs.GetInt(TotalPlaysPref);
            averagePlayTime = PlayerPrefs.GetFloat(AverageTimePref);
            totalTicketsPaid = PlayerPrefs.GetInt(TotalTicketsPref);
            lowestTicketPayout = PlayerPrefs.GetInt(LowestTicketPayoutPref);
            highestTicketPayout = PlayerPrefs.GetInt(HighestTicketPayoutPref);
        }

    }

    // Update is called once per frame
    void Update()
    {
        dataText.text = "\n" +
               "credits: " + credits + "\n" +
               "totalRunTime: " + totalRunTime + "\n" +
               "totalCreditsTaken: " + totalCreditsTaken + "\n" +
               "totalPlays: " + totalPlays + "\n" +
               "averagePlayTime: " + averagePlayTime + "\n" +
               "totalTicketsPaid: " + totalTicketsPaid + "\n" +
               "lowestTicketPayout: " + lowestTicketPayout + "\n" +
               "highestTicketPayout: " + highestTicketPayout + "\n" +
               "";
    }
}
