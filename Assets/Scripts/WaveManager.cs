using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public TextMeshProUGUI waveNumText;
    public TextMeshProUGUI gameOverHighestWave;

    public TextMeshProUGUI waveIndicator;
    public TextMeshProUGUI waveIndicatorNum;

    private void Start()
    {
        gameOverHighestWave.text = 1.ToString();
        ShowWaveIndicator();
        StartCoroutine("ShowDelayedWave1");
    }

    public void UpdateWaveText(int waveNumber)
    {
        waveNumText.text = waveNumber.ToString();
        waveIndicatorNum.text = waveNumber.ToString();
        gameOverHighestWave.text = waveNumber.ToString();
    }

    public void ShowWaveIndicator()
    {
        waveIndicator.gameObject.SetActive(true);
        waveIndicatorNum.gameObject.SetActive(true);
    }

    public void HideWaveIndicator()
    {
        waveIndicator.gameObject.SetActive(false);
        waveIndicatorNum.gameObject.SetActive(false);
    }

    private IEnumerator ShowDelayedWave1()
    {
        yield return new WaitForSeconds(2);

        HideWaveIndicator();
    }
}
