using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatsSliderUpdater : MonoBehaviour
{
    public Slider sl;
    GameManager gm;
    float fatTarget = 72.57478f; // 0.16 pounds a day

    void awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //100 is a dummy value for the intake value tentatively
        sl.value = 100 / fatTarget;
        // if sl.value > 0.6, then things start happening to pet
        if (sl.value > 0.6)
        {
            Debug.Log("STOP EATING FATS"); // tentative output. pet becomes zombie-like.
        }
    }
}
