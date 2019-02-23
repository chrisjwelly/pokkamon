using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbSliderUpdater : MonoBehaviour
{
    //public string stat;
    public Slider sl;
    GameManager gm;
    //public float carbs;
    public float weight;
    public string gender;

    void awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public float calorieTarget(float weight)
    { // get calorie in grams
        return weight * 24;
    }

    public float carbsTarget()
    {
        return (calorieTarget(weight) / 4) * 0.65f;
    }
    void Update()
    {
        //100 is a dummy value for the intake value tentatively
        sl.value = 100 / carbsTarget();
        // if sl.value > 0.6, then things start happening to pet
        if (sl.value > 0.6)
        {
            Debug.Log("STOP EATING CARBS"); // tentative output. pet becomes zombie-like.
        }
    }
}
