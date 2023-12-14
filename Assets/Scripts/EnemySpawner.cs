using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<GameObject> enemyList;
    public GameObject type1Enemy;
    public GameObject type2Enemy;
    public GameObject type3Enemy;
    public int wave1NumEnemies;

    void Start()
    {
        enemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 50; i <= wave1NumEnemies; i--)
        {
            
        }
    }
}
