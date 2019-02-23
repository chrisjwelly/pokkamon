using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;


public class BMICalc : MonoBehaviour
{
    private const string API_LINK = "https://gabamnml-health-v1.p.rapidapi.com/bmi";
    private const string API_KEY = "8d83ebf72cmshe58465d5ac91e85p13ec4cjsnc46687bd8d29";
    public InputField HEIGHT;
    public InputField WEIGHT;
    private string FIELDS;
    public Text responseText;
 

    public void Request()
    {
        WWWForm form = new WWWForm();
        FIELDS = "?weight=" + WEIGHT.text + "&&height=" + HEIGHT.text;
        Dictionary<string, string> headers = form.headers;
        headers["X-RapidAPI-Key"] = API_KEY;
        //headers["Content-Type"] = "application/json";
        //string EDITED_INPUT = INPUT.text.Replace(" ", "%20");
        string CONCAT = API_LINK + FIELDS;
        Debug.Log(CONCAT);
 
            WWW request = new WWW(CONCAT,  null,  headers);
            StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        string my_string = req.text;
        JSONNode data = JSON.Parse(my_string);
        Debug.Log(data);
        
        //converts the number to float!!
        float.TryParse(data["result"].Value, out float something);
        Debug.Log(something);
        if (data["max_score"].Value == "null")
        {
            responseText.text = "Invalid data. Please input again";
        }
        else
        {
            responseText.text = "BMI: " + (something).ToString("0.00");
        }
    }
}
