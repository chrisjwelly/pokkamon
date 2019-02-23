using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;


public class API2 : MonoBehaviour
{
    private const string NUTRITION = "https://nutritionix-api.p.rapidapi.com/v1_1/search/";
    private const string API_KEY = "badef3930emsh11a0eab9caf9d9ep180fbejsna1fa312cb3f1";
    //private const string INPUT = "cheddar cheese"; // should be flexible for input
    public InputField INPUT;
    private const string FIELDS = "?fields=item_name%2Citem_id%2Cbrand_name%2Cnf_calories%2Cnf_total_fat";
    public Text responseText;

    public void Request()
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = form.headers;
        headers["X-RapidAPI-Key"] = API_KEY;
        string EDITED_INPUT = INPUT.text.Replace(" ", "%20");
        //Debug.Log(EDITED_INPUT);
        string CONCAT = NUTRITION + EDITED_INPUT + FIELDS;
        //Debug.Log(CONCAT);
        WWW request = new WWW(CONCAT, null, headers);

        StartCoroutine(OnResponse(request));
        //Debug.Log(response)
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        string my_string = req.text;
        JSONNode data = JSON.Parse(my_string);


        //converts the number to float!!
        float.TryParse(data["hits"][0]["fields"]["nf_total_fat"].Value, out float something);
        Debug.Log(something);
        responseText.text = (something).ToString("0.00");
        //data["hits"][0]["fields"]["nf_total_fat"].Value

    }
}
