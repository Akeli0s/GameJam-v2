using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveManager waveManager;
    private bool waveStart = true;
    private int waveNum;
    private int waveStartEnemy = 50;
    private AIPath type1;
    private AIPath type2;
    private AIPath type3;
    public GameObject type1Enemy;
    public GameObject type2Enemy;
    public GameObject type3Enemy;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
    public GameObject spawner6;
    public GameObject spawner7;
    public GameObject spawner8;
    public GameObject spawner9;
    public GameObject spawner10;
    public GameObject spawner11;
    public GameObject spawner12;
    public GameObject spawner13;
    public GameObject spawner14;
    public GameObject spawner15;
    public GameObject spawner16;
    private GameObject[] spawners;
    public float timer;
    public int waveNumEnemies;

    void Start()
    {
        type1 = GetComponent<AIPath>();
        type2 = GetComponent<AIPath>();
        type3 = GetComponent<AIPath>();
        waveNum = 1;
        waveNumEnemies = waveStartEnemy;
        spawners = new GameObject[16] { spawner1, spawner2, spawner3, spawner4, spawner5, spawner6, spawner7, spawner8, spawner9, spawner10, spawner11, spawner12, spawner13, spawner14, spawner15, spawner16, };
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (waveNumEnemies > 0)
        {
            if (timer > 1)
            {
                timer = 0;

                int randomEnemy = Random.Range(0, 3);
                int randomSpawner = Random.Range(0, 16);
                switch (randomEnemy)
                {
                    case 0:
                        Instantiate(type1Enemy, spawners[randomSpawner].transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(type2Enemy, spawners[randomSpawner].transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(type3Enemy, spawners[randomSpawner].transform.position, Quaternion.identity);
                        break;
                }

                waveNumEnemies--;
            }
        }

        if (waveStart == true)
        {
            if (waveNum <= 10)
            {
                if (waveNumEnemies < 1)
                {
                    waveStart = false;
                    waveNum += 1;
                    waveNumEnemies += waveStartEnemy * + 25;
                    waveManager.UpdateWaveText(waveNum);
                    waveManager.ShowWaveIndicator();
                    StartCoroutine(DelaySpawn());
                }
            }
        }
    }

    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(2);

        waveStart = true;
        type1.maxSpeed += 0.5f;
        waveManager.HideWaveIndicator();
    }
}
