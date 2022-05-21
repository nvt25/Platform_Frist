using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : EnemyMode
{
    void Update()
    {
        checkTurn();
        base.distanceToPlayer();
        base.enemyAttack();
    }
    private void checkTurn(){
        base.enemyMove(true);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Destroy_enemy")){
            Destroy(gameObject);
        }
    }
}
