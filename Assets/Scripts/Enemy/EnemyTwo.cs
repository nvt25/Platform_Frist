using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : EnemyMode
{
    public GameObject bullet;
    public Transform posShoot;
    [SerializeField] private float timeLookShoot = 1;
     [SerializeField] Transform startPos,endPos;
    void Update()
    {
        checkTurn();
        base.distanceToPlayer();
        this.enemyAttack();
    }
    private void checkTurn(){
        bool turn =  Physics2D.Linecast(this.startPos.position,this.endPos.position,1<<LayerMask.NameToLayer("Ground"));
        base.enemyMove(turn);
    }
    public override void enemyAttack(){
        if(base.isAttack&&this.timeLookShoot>0.9f){
            StartCoroutine(waitShoot());
            this.timeLookShoot = 0;
        }else{
            this.timeLookShoot +=Time.deltaTime;
        }
        base.enemyAttack();

    }
    IEnumerator waitShoot(){
        yield return new WaitForSeconds(0.6f);
        GameObject bullet = Instantiate(this.bullet);
        bullet.transform.position = this.posShoot.position;
    }
}
