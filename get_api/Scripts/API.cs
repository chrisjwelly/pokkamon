using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class API : MonoBehaviour
{
    private const string WANIKANI = "https://www.wanikani.com/api/user/";
    private const string API_KEY = "0b568e49484922c20868f65e9469f217";
    public Text responseText;

    public void Request()
    {
        WWW request = new WWW(WANIKANI + API_KEY);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;

        responseText.text = req.text;
    }
}
