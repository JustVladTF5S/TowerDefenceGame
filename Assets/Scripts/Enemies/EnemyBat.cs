using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : BaseEnemy
{ 
   override public void Start(){
        base.Start();

        damage = 10;
        health = 200.0f;
        speed = 2.2f;

        walkAnimationsName = "BatRun";
        dieAnimationsName = "Die";
        damageAnimationsName = "Hurt";

    }

    override protected void moveEnemy(){
        base.moveEnemy();
        damage += 1;
    }

}
