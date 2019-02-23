using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User 
{
    public string userName;
    public float userScore;

    public User(string _userName, float _userScore) {
        //userName = PlayerScores.playerName;
        //userScore = PlayerScores.playerScore;

        userName = _userName;
        userScore = _userScore;
    }
}
