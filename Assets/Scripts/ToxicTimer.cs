using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToxicTimer : MonoBehaviour
{
    public TextMeshProUGUI toxicTimer;
    public float toxTimer = 20f;
    public int antidotesGathered = 0;

    private void Start()
    {
        toxTimer = 20f;
    }

    private void Update()
    {
        if (antidotesGathered == 3)
        {
            toxTimer = 20f;
        }

        toxTimer -= Time.deltaTime;
        toxicTimer.text = Mathf.Floor(toxTimer).ToString() + " sec.";
    }
}
