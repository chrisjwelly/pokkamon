using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarSliderUpdater : MonoBehaviour
{
    public Slider sl;
    GameManager gm;
    public string gender;

    void awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public int sugarTarget()
    {
        if (gender == "Female")
        {
            return 25;
        }
        else // if male
        {
            return 29;
        }
    }

    void Update()
    {
        //100 is a dummy value for the intake value tentatively
        sl.value = 100 / sugarTarget();
        // if sl.value > 0.6, then things start happening to pet
        if (sl.value > 0.6)
        {
            Debug.Log("STOP EATING SUGAR"); // tentative output. pet becomes zombie-like.
        }
    }
}
