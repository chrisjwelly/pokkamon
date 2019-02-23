using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON; // This is very important in order to convert the string to JSON


public class API2 : MonoBehaviour
{

    private const string NUTRITION = "https://nutritionix-api.p.rapidapi.com/v1_1/search/";
    private const string API_KEY = "badef3930emsh11a0eab9caf9d9ep180fbejsna1fa312cb3f1";
    public InputField INPUT;
    // specifies the necessary fields desired. Edit this according to what you need
    private const string FIELDS = "?fields=item_name%2Citem_id%2Cbrand_name%2Cnf_calories%2Cnf_total_fat";
    public Text responseText;

    public void Request()
    {
        // the next 3 lines are with reference online. Not really sure what is happening
        WWWForm form = new WWWForm();
        Dictionary<string, string> headers = form.headers;
        headers["X-RapidAPI-Key"] = API_KEY;
        // %20 replaces a blank space in a URL
        string EDITED_INPUT = INPUT.text.Replace(" ", "%20");
        string CONCAT = NUTRITION + EDITED_INPUT + FIELDS;
        WWW request = new WWW(CONCAT, null, headers);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        // some magic for the next 3 lines
        yield return req;
        string my_string = req.text;
        JSONNode data = JSON.Parse(my_string);

        // converts the number to float!! required for future arithmetic manipulation 
        float.TryParse(data["hits"][0]["fields"]["nf_total_fat"].Value, out float fat_consumed);
        if (data["max_score"].Value == "null") // in the case of no data being fetched from the database
        {
            responseText.text = "Invalid data. Please input again";
        }
        else
        {
            responseText.text = "Total fat consumed is: " + (fat_consumed).ToString("0.00");
        }
    }
}
