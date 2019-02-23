using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;

    private System.Random random = new System.Random();

    User user = new User();

    public static int playerScore;
    public static string playerName;
    

    // Start is called before the first frame update
    void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
    }

    public void OnSubmit() {
        playerName = nameText.text;
        PostToDatabase();
        
    }

    public void OnGetScore()
    {
        RetrieveFromDatabase();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + user.userScore;
    }

    public void PostToDatabase() {

        User user = new User();
        RestClient.Put("https://pokkamon-67523.firebaseio.com/"+playerName+".json",  user);
        Debug.Log("submitted!");
    }

    public void RetrieveFromDatabase()
    {
       
        RestClient.Get<User>("https://pokkamon-67523.firebaseio.com/" + nameText .text + ".json").Then(response => {
            user = response;
            UpdateScore();
        });
        Debug.Log("retrieved!");
    }
  

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
