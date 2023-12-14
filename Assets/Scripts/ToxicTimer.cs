using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToxicTimer : MonoBehaviour
{
    public TextMeshProUGUI toxicTimer;
    public float toxTimer = 14f;
    public int antidotesGathered = 0;

    private void Start()
    {
        toxTimer = 14f;
    }

    private void Update()
    {
        if (antidotesGathered == 5)
        {
            toxTimer = 14f;
            antidotesGathered = 0;
        }

        toxTimer -= Time.deltaTime;
        toxicTimer.text = Mathf.Floor(toxTimer).ToString() + " sec.";
    }
}
