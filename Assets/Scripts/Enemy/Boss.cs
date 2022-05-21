using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyMode
{

    private float vel;
    private Transform homeBoss;
    private Vector3 distanceHomeBoss; 
    private void Start() {
        this.homeBoss = GameObject.Find("Home_Boss").transform;
    }
    void Update()
    {
        base.distanceToPlayer();
        base.enemyAttack();
        runFollowPlayer();
        vectorFaceEnemy();
        GetDistanceHomeBoss();
        RunGoHome();
        enemyWalk();
    }
    private void runFollowPlayer(){
        if(base.distance.magnitude < 10f&& base.distance.magnitude >2f && base.distance.y < 3f){
            this.vel = 1;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,base.player.transform.position,base.speedMove * Time.deltaTime);
        }else{
            this.vel = 0;
        }
    }
    private void vectorFaceEnemy(){
        Vector3 tempPos = transform.localScale;
        if(base.distance.x > 0){
            tempPos.x = base.vectorScale;
        }else{
            tempPos.x = -base.vectorScale;
        }
        transform.localScale = tempPos;
    }
    private void vectorFaceEnemy(bool a){
        Vector3 tempPos = transform.localScale;
        tempPos.x = base.vectorScale;
        transform.localScale = tempPos;
    }
    void enemyWalk(){
        base.anim.SetFloat("Is_walk",this.vel);
    }
    void GetDistanceHomeBoss(){
        this.distanceHomeBoss = this.homeBoss.position - gameObject.transform.position;
    }
    void RunGoHome(){
        if(base.distance.magnitude > 10f || base.distance.y >3f){
            if(this.distanceHomeBoss.x>0){
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,this.homeBoss.transform.gameObject.transform.position,base.speedMove * Time.deltaTime);
                this.vel = 1;
                vectorFaceEnemy(true);
            }else{
                this.vel = 0;
            }
        }
    }
}
