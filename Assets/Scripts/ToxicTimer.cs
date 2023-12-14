using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToxicTimer : MonoBehaviour
{
    public TextMeshProUGUI toxicTimer;
    public float toxTimer = 7f;
    public int antidotesGathered = 0;

    private void Start()
    {
        toxTimer = 12f;
    }

    private void Update()
    {
        if (antidotesGathered == 3)
        {
            toxTimer = 12f;
        }

        toxTimer -= Time.deltaTime;
        toxicTimer.text = Mathf.Floor(toxTimer).ToString() + " sec.";
    }
}
