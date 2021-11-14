using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour
{
    public GameObject baseEnemy;

    public GameObject bat2;

    public Text userText;
    private LevelData data;
    private WaveData currentWave;
    private int spawnedEnemies;
    private int waveIndex;

    private int userHealth = 100;

    void Start()
    {
        userText.text = userHealth.ToString();
        StreamReader reader = new StreamReader(Application.dataPath + "//config.json");
        string fileContent = reader.ReadToEnd();

        data = JsonUtility.FromJson<LevelData>(fileContent);
        waveIndex = 0;
        currentWave = data.waves[waveIndex];
        spawnedEnemies = 0;
        

        //userText.text = userHealth.toString() + "/" + maxHelath.toString();
        userText.text = userHealth.ToString();
        InvokeRepeating("CreateNewEnemy", currentWave.delay, 1.5f);
    }

    void CreateNewEnemy() {
        if (spawnedEnemies < currentWave.enemies.Length) {

            if (currentWave.enemies[spawnedEnemies] == EnemyTypes.BAT_TYPE) {
                CreateBat();
            } else {
                CreateBat2();
            }

            GameObject newEnemy = GameObject.Instantiate(baseEnemy);
            BaseEnemy enemyScript = newEnemy.GetComponent<BaseEnemy>();

            enemyScript.EnemyFinish += EnemyFinishCallback;
            spawnedEnemies = spawnedEnemies + 1;
        } else if (waveIndex < data.waves.Count - 1) {
            CancelInvoke("CreateNewEnemy");
            waveIndex = waveIndex + 1;
            spawnedEnemies = 0;
            currentWave = data.waves[waveIndex];
            InvokeRepeating("CreateNewEnemy", currentWave.delay, 1.5f);
        }

    }

    void CreateBat() {
        GameObject newEnemy = GameObject.Instantiate(baseEnemy);
        EnemyBat enemyScript = newEnemy.GetComponent<EnemyBat>();

        enemyScript.EnemyFinish += EnemyFinishCallback;
    }

    void CreateBat2() {
        GameObject newEnemy = GameObject.Instantiate(bat2);
        EnemyBat2 enemyScript = newEnemy.GetComponent<EnemyBat2>();

        enemyScript.EnemyFinish += EnemyFinishCallback;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyFinishCallback (BaseEnemy bat) {
        userHealth -= bat.damage;
        userText.text = userHealth.ToString();
    }

}