using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using Proyecto26;

public class API2 : MonoBehaviour
{
    private const string NUTRITION = "https://nutritionix-api.p.rapidapi.com/v1_1/search/";
    private const string API_KEY = "badef3930emsh11a0eab9caf9d9ep180fbejsna1fa312cb3f1";
    public InputField INPUT;
    private const string FIELDS = "?fields=brand_name%2Cnf_total_carbohydrate%2Cnf_calories%2Cnf_total_fat%2Cnf_protein";
    public Text fatsText, caloriesText, carbsText, proteinsText, responseText;
    public string playerName;
    public  float playerScore;
    //User user = new User();

    public void Request()
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers;
        headers["X-RapidAPI-Key"] = API_KEY;
        string EDITED_INPUT = INPUT.text.Replace(" ", "%20");
        string CONCAT = NUTRITION + EDITED_INPUT + FIELDS;
        WWW request = new WWW(CONCAT, null, headers);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        string my_string = req.text;
        JSONNode data = JSON.Parse(my_string);


        //converts the number to float!!
        
        float.TryParse(data["hits"][0]["fields"]["nf_total_carbohydrate"].Value, out float carbs);
        float.TryParse(data["hits"][0]["fields"]["nf_protein"].Value, out float proteins);
        Debug.Log("Carbs: " + carbs);
        Debug.Log("Protein: " + proteins);
        float.TryParse(data["hits"][0]["fields"]["nf_total_fat"].Value, out float fats);
        float.TryParse(data["hits"][0]["fields"]["nf_calories"].Value, out float calories);
        //Debug.Log(fats);
        if (data["max_score"].Value == "null")
        {
            responseText.text = "Invalid data. Please input again";
        }
        else
        {

            carbsText.text = "Carbs intake: " + (carbs).ToString("0.00");
            RetrieveFromDatabase("Carbs counter", carbs);
            Debug.Log(carbs);

            proteinsText.text = "Protein intake: " + (proteins).ToString("0.00");
            RetrieveFromDatabase("Protein counter", proteins);
            Debug.Log(proteins);

            fatsText.text = "Fat intake: " + (fats).ToString("0.00");
            RetrieveFromDatabase("Fat counter", fats);

            caloriesText.text = "Calories intake: " + (calories).ToString("0.00");
            RetrieveFromDatabase("Calorie counter", calories);

            
            
        }
    }

    public void PostToDatabase(string name, float  something)
    {

        playerName = name;
        playerScore = something;
        User user = new User(playerName, playerScore);
        

        RestClient.Put("https://pokkamon-67523.firebaseio.com/" + playerName + ".json", user);
        Debug.Log("submitted!");
    }

    public void RetrieveFromDatabase(string name, float something)
    {

        playerName = name;
        User user = new User(playerName, playerScore);
        RestClient.Get<User>("https://pokkamon-67523.firebaseio.com/" + playerName + ".json").Then(response => {
            user = response;
            PostToDatabase(name, user.userScore + something);
        });
        Debug.Log("retrieved!");
    }
}
