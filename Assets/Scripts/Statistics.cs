using System;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    // Keys for stored data
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
    
    private float _gameStartTime = -1;
    private float _lastSavedTime = 0;

    public int credits;
    public float totalRunTime;
    public int totalCreditsTaken;
    public int totalPlays;
    public float averagePlayTime;
    public int totalTicketsPaid;
    public int lowestTicketPayout = -1;
    public int highestTicketPayout = -1;

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
    
    public void GameStarted()
    {
        _gameStartTime = Time.time;
    }

    private void Update()
    {
        totalRunTime += Time.time - _lastSavedTime;
        _lastSavedTime = Time.time;
    }

    public void GameComplete(int ticketsPaid)
    {
        float gameLength = Time.time - _gameStartTime;
        
        Debug.Log("Game lasted " + gameLength + "s");
        _gameStartTime = -1;
        averagePlayTime = ((averagePlayTime * totalPlays) + gameLength) / (totalPlays + 1);
        totalPlays += 1;
        totalTicketsPaid += ticketsPaid;
        if (ticketsPaid < lowestTicketPayout || lowestTicketPayout == -1)
        {
            lowestTicketPayout = ticketsPaid;
        }

        if (ticketsPaid > highestTicketPayout || highestTicketPayout == -1)
        {
            highestTicketPayout = ticketsPaid;
        }
    }

    private void SaveStats()
    {
        PlayerPrefs.SetInt(CreditsPref, 0);
        PlayerPrefs.SetFloat(TotalTimePref, totalRunTime);
        PlayerPrefs.SetInt(TotalCreditsPref, totalCreditsTaken);
        PlayerPrefs.SetInt(TotalPlaysPref, totalPlays);
        PlayerPrefs.SetFloat(AverageTimePref, averagePlayTime);
        PlayerPrefs.SetInt(TotalTicketsPref, totalTicketsPaid);
        PlayerPrefs.SetInt(LowestTicketPayoutPref, lowestTicketPayout);
        PlayerPrefs.SetInt(HighestTicketPayoutPref, highestTicketPayout);
        PlayerPrefs.SetInt(DataVersionPref, 1);
        
        Debug.Log(this);
        
        PlayerPrefs.Save();
    }

    void OnDestroy()
    {
        SaveStats();
    }
    
    public void AddCredits()
    {
        Debug.Log("coined up");
        credits++;
        totalCreditsTaken++;
        PlayerPrefs.SetInt(CreditsPref, credits);
    }

    public void RemoveCredits()
    {
        credits--;
        PlayerPrefs.SetInt(CreditsPref, credits);
    }

    public void ResetMachine()
    {
        PlayerPrefs.DeleteAll();
    }

    public override string ToString()
    {
        return "{\n" +
               "credits: " + credits + "\n" +
               "totalRunTime: " + totalRunTime + "\n" +
               "totalCreditsTaken: " + totalCreditsTaken + "\n" +
               "totalPlays: " + totalPlays + "\n" +
               "averagePlayTime: " + averagePlayTime + "\n" +
               "totalTicketsPaid: " + totalTicketsPaid + "\n" +
               "lowestTicketPayout: " + lowestTicketPayout + "\n" +
               "highestTicketPayout: " + highestTicketPayout + "\n" +
               "}";
    }
}
