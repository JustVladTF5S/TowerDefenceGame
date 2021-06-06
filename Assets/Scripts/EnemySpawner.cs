using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject baseEnemy;

    public Text userText;

    private int userHealth = 100;

    void Start()
    {
        userText.text = userHealth.ToString();
        InvokeRepeating("CreateNewEnemy",1.0f,2.0f);
    }

    void CreateNewEnemy() {
        GameObject newEnemy = GameObject.Instantiate(baseEnemy);
        EnemyBat enemyScript = newEnemy.GetComponent<EnemyBat>();

        enemyScript.EnemyFinish += EnemyFinishCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyFinishCallback (EnemyBat bat) {
        userHealth -= bat.damage;
        userText.text = userHealth.ToString();
    }

}