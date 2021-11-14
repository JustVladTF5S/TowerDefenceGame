using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : MonoBehaviour
{
    public FadeEffect effectScript;
    float damage = 100.0f;
    List<BaseEnemy> enemies = new List<BaseEnemy>();

    
    void Start()
    {
        InvokeRepeating("TowerShot", 1.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TowerShot() {
        if (enemies.Count > 0){
            effectScript.StartFade();
            enemies[0].doDamage(damage);
        }
    }
    void OnEnemyDied(BaseEnemy enemy){
        enemies.Remove(enemy);

    }


 void OnTriggerEnter2D(Collider2D collider)
 {
    GameObject enemyObject = collider.gameObject;
    BaseEnemy enemyScript = enemyObject.GetComponent<BaseEnemy>();
    enemyScript.EnemyDied += OnEnemyDied;
    enemies.Add(enemyScript);
    print("Enemy enter");
 }
 void OnTriggerExit2D(Collider2D collider)
 {
    GameObject enemyObject = collider.gameObject;
    BaseEnemy enemyScript = enemyObject.GetComponent<BaseEnemy>();
    enemyScript.EnemyDied -= OnEnemyDied;
    enemies.Remove(enemyScript);
   
   
    print("Enemy exit");





 }

}
