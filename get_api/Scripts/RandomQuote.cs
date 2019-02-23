using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON; // This is very important in order to convert the string to JSON


public class RandomQuote : MonoBehaviour
{

    private const string QUOTES = "https://quotes-and-proverbs.p.rapidapi.com/rapidapiquotes?random=1";
    private const string API_KEY = "badef3930emsh11a0eab9caf9d9ep180fbejsna1fa312cb3f1";
    public InputField INPUT;
    // specifies the necessary fields desired. Edit this according to what you need
    //private const string FIELDS = "?fields=item_name%2Citem_id%2Cbrand_name%2Cnf_calories%2Cnf_total_fat";
    public Text responseText;

    public void Request()
    {
        // the next 3 lines are with reference online. Not really sure what is happening
        WWWForm form = new WWWForm();
        Dictionary<string, string> headers = form.headers;
        headers["X-RapidAPI-Key"] = API_KEY;
        // %20 replaces a blank space in a URL
        //string EDITED_INPUT = INPUT.text.Replace(" ", "%20");
        //string CONCAT = NUTRITION + EDITED_INPUT + FIELDS;
        WWW request = new WWW(QUOTES, null, headers);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        // some magic for the next 3 lines
        yield return req;
        string my_string = req.text;
        JSONNode data = JSON.Parse(my_string);

        string AUTHOR = data["a"].Value;
        string QUOTE = data["q"].Value;
        responseText.text = AUTHOR + " says that: " + QUOTE;
    }

}
