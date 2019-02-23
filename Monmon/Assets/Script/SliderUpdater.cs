using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    public string stat;
    public Slider sl;
    GameManager gm;
    void awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update ()
    {
       // sl.value = gm.calculateStat(stat)/ gm.getSuggestedStat(stat);
    }
}
