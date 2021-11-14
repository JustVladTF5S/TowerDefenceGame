using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public delegate void EnemyListener(BaseEnemy enemy);
    public event EnemyListener EnemyFinish;
    public event EnemyListener EnemyDied;

    public SpriteRenderer renderer;
    public Animator animator;
    public int damage = 4;

   public float health = 100.0f;
    public float speed = 1.1f;
    int index = 0;
    bool isMoving = false;

    Vector3 target;
    List<GameObject> checkpoints = new List<GameObject>();
    protected string walkAnimationsName;
    protected string damageAnimationsName;
    protected string dieAnimationsName;


    // Start is called before the first frame update
    virtual public void Start()
    {
        checkpoints.Add(GameObject.Find("ch1"));
        checkpoints.Add(GameObject.Find("ch2"));
        checkpoints.Add(GameObject.Find("ch3"));
        checkpoints.Add(GameObject.Find("ch4"));
        checkpoints.Add(GameObject.Find("ch5"));
        checkpoints.Add(GameObject.Find("ch6"));
        checkpoints.Add(GameObject.Find("ch7"));
        checkpoints.Add(GameObject.Find("ch8"));
        checkpoints.Add(GameObject.Find("ch9"));
        checkpoints.Add(GameObject.Find("ch10"));

        target = checkpoints[index].transform.position;
        isMoving = true;

        GameObject startObject = GameObject.Find("ch0");
        transform.position = startObject.transform.position;
        
    }

    void Update()
    {
        if (isMoving == true) {
            moveEnemy();
        }
    }

    virtual protected void moveEnemy() 
    {
        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        float distance = Vector3.Distance(transform.position, target);
        if (distance < 0.1f) {
            index++;
            if (index < checkpoints.Count) {
                target = checkpoints[index].transform.position;
            } else {
                if (EnemyFinish != null) {
                    EnemyFinish(this);
                }
                GameObject.Destroy(gameObject);
            }
        }
    }

    public void doDamage(float inputDamage) 
    {
        //health = health - inputDamage;
        health -= inputDamage;
        if (health <= 0) 
        {
            if (EnemyDied != null) {
                EnemyDied(this);
            }
            isMoving = false;
            animator.Play(dieAnimationsName);
        } else {
            isMoving = false;
            animator.Play(damageAnimationsName);
        }
    }

    public void endDieAnimation() {
        GameObject.Destroy(gameObject);
    }

    public void endHurtAnimation() {
        isMoving = true;
        animator.Play(walkAnimationsName);
    }
}
