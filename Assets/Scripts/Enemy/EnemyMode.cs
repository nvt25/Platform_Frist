using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMode : MonoBehaviour
{
    public float distanceStop;
    public GameObject dieNo;
    public AudioSource aus;
    public AudioClip noAu;
    private float hpEnemyValue;
    [SerializeField] private float hpEnemyMax;
    public Transform player;
    public HpEnemy hpEnemy;
    [SerializeField] protected float speedMove;
    [SerializeField] private float distancePlayer;
    [SerializeField] private float distanceAttack;
    protected bool isAttack;
    protected Rigidbody2D myBody;
    protected Animator anim;
    protected float vectorScale;
    protected Vector3 distance;
    void Awake()
    {
        if(player == null){
            this.player = GameObject.Find("player_1").transform;
        }
        this.myBody = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.isAttack = false;
        this.vectorScale = Mathf.Abs(transform.localScale.x);
        this.hpEnemyValue = this.hpEnemyMax;
    }
    protected void distanceToPlayer(){
        this.distance = this.player.position - transform.position;
    }
    private void nearPlayer(){
        if(distance.magnitude < this.distancePlayer){
            Vector3 vectorTemp = transform.localScale;
            if(distance.x>0){
                vectorTemp.x = this.vectorScale;
            }else{
                vectorTemp.x = -this.vectorScale;
            }
            transform.localScale = vectorTemp;
        }
    }
    protected void enemyMove(bool isTurn){
        if(!isTurn&&distance.magnitude > this.distancePlayer){
            Vector3 vectorTemp = transform.localScale;
            if(vectorTemp.x > 0){
                vectorTemp.x = -this.vectorScale;
            }else{
                vectorTemp.x = this.vectorScale;
            }
            transform.localScale = vectorTemp;
        }
        if(isTurn&& Mathf.Abs(distance.x) >this.distanceStop){
            Vector2 _move = new Vector2(transform.localScale.x * this.speedMove *Time.deltaTime,0);
            transform.Translate(_move);
        }
        nearPlayer();
    }
    protected void checkAttack(){
        this.isAttack = distance.magnitude < this.distanceAttack ?true:false;
    }
    public virtual void enemyAttack(){
        this.checkAttack();
        if(this.isAttack){
            this.anim.SetBool("Is_attack",this.isAttack);
        }else{
            this.anim.SetBool("Is_attack",this.isAttack);
        }
    }
    public void SetHp(float damage){
        this.hpEnemyValue -= damage;
        this.hpEnemy.setHpEnemy(this.hpEnemyValue,this.hpEnemyMax); 
        if(this.hpEnemyValue<=0){
            if(this.aus && this.noAu){
                this.aus.PlayOneShot(this.noAu);
            }
            Instantiate(this.dieNo,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    } 

}
