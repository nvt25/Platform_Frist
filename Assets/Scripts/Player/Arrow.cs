using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject damagerText;
    private PlayerControler player;
    [SerializeField] private float shootForce;
    private float shootVector;
    private Rigidbody2D myBody;
    private int damagerMax = 8;
    private int damagerMin = 6;
    private bool isDeadly;
    private int percent;
    private int valueDamager;
    private void Awake() {
        this.myBody = GetComponent<Rigidbody2D>();
        this.player = FindObjectOfType<PlayerControler>();
        this.shootVector = this.player.getVectorFace();
    }
    void Start()
    {
        Destroy(gameObject,1f);
        this.arrowVector();
        this.percent = 50;
        this.deadly();
        this.setValueDamager();
        this.ChiMang();
    }
    private void arrowVector(){
        Vector3 tempScale = transform.localScale;
        tempScale.x = this.shootVector;
        transform.localScale = tempScale;
    }
    private void deadly(){
        int randomPercent = Random.Range(0,100);
        this.isDeadly = randomPercent <= this.percent ? true : false;
    }
    private void setValueDamager(){
        int valueDam = Random.Range(this.damagerMin,this.damagerMax);
        this.valueDamager = this.isDeadly ? valueDam * 2 : valueDam;
    }
    void Update()
    {
         transform.Rotate(new Vector3(30,0,0));
         this.myBody.velocity= new Vector2(this.shootVector * this.shootForce,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<EnemyMode>().SetHp(this.valueDamager);
            // tao textDameger
            GameObject damagerPop = Instantiate(this.damagerText,other.transform.position + new Vector3(0,1.2f,0),Quaternion.identity);
            TmpText tmpText = damagerPop.GetComponent<TmpText>();
            tmpText.setUp(this.valueDamager,this.isDeadly);
            Destroy(gameObject);
        }
    }
    private void ChiMang(){
        GameObject total = transform.Find("Total").gameObject;
        if(this.isDeadly){
            total.SetActive(true);
        }else{
            total.SetActive(false);
        }
    }
}
