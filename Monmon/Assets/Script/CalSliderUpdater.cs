using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalSliderUpdater : MonoBehaviour
{
    public Slider sl;
    GameManager gm;
    public float weight = 500; // dummy value
    public string gender;

    void awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public float calorieTarget(float weight)
    { // get calorie in grams
        return weight * 24;
    }

    void Update()
    {
        //100 is a dummy value for the intake value tentatively
        sl.value = 100 / calorieTarget(weight);
        // if sl.value > 0.6, then things start happening to pet
        if (sl.value > 0.6)
        {
            Debug.Log("STOP EATING CALORIE-LADEN FOOD"); // tentative output. pet becomes zombie-like.
        }
    }
}
