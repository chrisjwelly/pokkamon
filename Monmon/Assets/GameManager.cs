using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TextMeshPro streakText;
    public TextMeshPro encouragement;
    public static int streakNum;
    //number of streak days

    private bool healthy;
    //healthiness of the pet

        //all the nutrition, will reset everyday
    private float carbs;
    private float calories;
    private float fat;
    private float protein;

    private float sugCarbs;
    private float sugCalories;
    private float sugFat;
    private float sugProtein;

    public Animator petAnimator;
    
   
    void Awake()
    {
        streakText.text = "🔥 " + streakNum +" day streak!! 🔥🔥";
        dayHealthyCheck();
    }
    public float calculateStat(String s)
    {
        switch(s){
            case "carbs":
                return carbs;
            case "calories":
                return calories;
            case "fat":
                return fat;
            case "protein":
                return protein;
            default:
                return 0f;
        }
    }
    public float getSuggestedStat(String s)
    {
        switch (s)
        {
            case "carbs":
                return sugCarbs;
            case "calories":
                return sugCalories;
            case "fat":
                return sugFat;
            case "protein":
                return sugProtein;
            default:
                return 0f;
        }
    }

    public void dayHealthyCheck()
    {

        string stringDate = PlayerPrefs.GetString("PlayDate");
        DateTime oldDate = Convert.ToDateTime(stringDate);
        DateTime newDate = System.DateTime.Now;
        Debug.Log("LastDay: " + oldDate);
        Debug.Log("CurrDay: " + newDate);

        TimeSpan difference = newDate.Subtract(oldDate);


        if (healthy)
        {
            streakNum += difference.Days;
        }
        else
        {
            streakNum = 0;
            encouragement.text = "Push on! You don't define yourself by how you succeed but by how you defied failure.";
        }
        /*if (difference.Days >= 1)
        {
            Debug.Log("New Reward!");
            string newStringDate = Convert.ToString(newDate);
            PlayerPrefs.SetString("PlayDate", newStringDate);
            //giveGift();
        }*/
    }

}
