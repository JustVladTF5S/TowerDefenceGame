using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat2 : BaseEnemy
{
   override public void Start(){
        base.Start();

        damage = 20;
        health = 400.0f;
        speed = 1.1f;

        walkAnimationsName = "move";
        dieAnimationsName = "die";
        damageAnimationsName = "damage";

    }
}
