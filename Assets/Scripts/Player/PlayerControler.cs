using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public AudioSource audioM;
    public AudioClip shootAu;
    private float timeLookShoot = 1f;
    public GameObject arrow;
    public Transform posShoot;
    [SerializeField] private float speedPlayer;
    [SerializeField] private float jumpPlayer;
    private float inputHorizontal;
    private float inputVertical;
    private bool isAttack;
    private float vectorFaceRoot;
    private float vectorFace;
    private Rigidbody2D myBody;
    private Animator animator;
    private BoxCollider2D col;
    // Start is called before the first frame update
    private void Start()
    {
        this.myBody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.col = GetComponent<BoxCollider2D>();
        this.vectorFaceRoot = Mathf.Abs(transform.localScale.x);
        this.vectorFace = transform.localScale.x;
    }

    // Update is called once per frame
    private void Update()
    {
        this.movePlayer();
        this.turnFacePlayer();
        this.shootArrow();
        this.controlAnimator();
        this.VfxSmoke();
    }
    public float getVectorFace(){
        return this.vectorFace;
    }
    private void movePlayer(){
        this.inputHorizontal = Input.GetAxis("Horizontal");
        this.inputVertical = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(this.inputHorizontal,0,0) * this.speedPlayer * Time.deltaTime;
        if(checkFly()&& (this.inputVertical>0.01||Input.GetKeyDown(KeyCode.Space))){
            this.myBody.AddForce(new Vector2(0,this.inputVertical * this.jumpPlayer), ForceMode2D.Impulse);
            if(myBody.velocity.y >0f) this.col.isTrigger = true;
            else this.col.isTrigger = false;
        }
        if(myBody.velocity.y >0.2f) this.col.isTrigger = true;
        else this.col.isTrigger = false;
    }
    private bool checkFly(){
        if(Mathf.Abs(myBody.velocity.y) <0.01){
            return true;
        }else{
            return false;
        }
    }
    private void turnFacePlayer(){
        Vector3 tempScale = transform.localScale;
        if(this.inputHorizontal > 0){
            tempScale.x = this.vectorFaceRoot;
        }else if(this.inputHorizontal < 0){
            tempScale.x = -this.vectorFaceRoot;
        }
        this.vectorFace = tempScale.x;
        transform.localScale = tempScale;
    }
    //shoot
    private void shootArrow(){
        if(this.timeLookShoot>0.72f){
            this.isAttack = Input.GetAxis("Fire1") !=0 ? true : false;
        }else{
            this.timeLookShoot += Time.deltaTime;
        }
        if(this.isAttack&&this.arrow != null&&this.posShoot!=null){
            this.timeLookShoot = 0;
            this.animator.SetTrigger("Is_attack");
            // GameObject arrow = Instantiate(this.arrow);
            // arrow.transform.position = this.posShoot.position;
            StartCoroutine(waitShoot());
            this.isAttack = false;
        }
    }
    IEnumerator waitShoot(){
        yield return new WaitForSeconds(0.68f);
        if(this.audioM && this.shootAu){
            this.audioM.PlayOneShot(this.shootAu);
        }
        GameObject arrow = Instantiate(this.arrow);
        arrow.transform.position = this.posShoot.position;
    }
    //end shoot
    private void controlAnimator(){
        this.aniRun();
        this.aniJump();
    }
    private void aniRun(){
        this.animator.SetFloat("Is_run",Mathf.Abs(this.inputHorizontal));
    }
    private void aniJump(){
        this.animator.SetBool("Is_jump",!checkFly());
    }
    private void VfxSmoke(){
            GameObject smoke =  transform.Find("Smoke").gameObject;
        if(checkFly() && this.inputHorizontal !=0){
            smoke.SetActive(true);
        }else{
            smoke.SetActive(false);
        }
    }
}
