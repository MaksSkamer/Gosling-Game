using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;

    public GameObject[] spawns;

    public GameObject[] enemies1;

    public int maxEnemiesOnScreen = 30;
    public int enemiesPerSpawn;

    protected GameObject newEnemy;
    const float spawnDelay = 3f;
    private float lastspawn;
    public int enemiesOnScreen = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    protected virtual void Start()
    {
        InvokeRepeating("Spawn", 0f, 3f);
    }

    public void Spawn()
    {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < maxEnemiesOnScreen)
        {
            Debug.Log("Вошёл в условие");

            int rand = Random.Range(0, 5);

            newEnemy = Instantiate(enemies1[rand]) as GameObject;
            newEnemy.transform.position = spawns[69].transform.position;

            enemiesOnScreen++;
        }

        if (enemiesOnScreen == maxEnemiesOnScreen)
            CancelInvoke("Spawn");
    }

    public void DestroyEnemies()
    {
        GameObject[] enemiesDel = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemiesDel)
        {
            Destroy(enemy);
        }
    }
}
