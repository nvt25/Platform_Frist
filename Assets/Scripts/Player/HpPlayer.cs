using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    public static HpPlayer instance;

    private Slider hpSlider;
    public float hpMax;
    public bool isDie;
    public int HpValueDeduct
    {
        set
        {
            if(value > 0) this.hpSlider.value -=  value;
            this.isDie = this.hpSlider.value <=0?true:false;
            GameManager.instance.IsGameOver = this.isDie;
        }
    }
    void Awake()
    {
        if(HpPlayer.instance != null) Debug.Log("Loi");
        HpPlayer.instance = this;

        this.initHp();
    }
    private void initHp(){  
        this.hpSlider  = GameObject.Find("HpSlider").GetComponent<Slider>();
        this.hpSlider.minValue = 0f;
        this.hpSlider.maxValue =this.hpMax;
        this.hpSlider.value = this.hpMax;
    }
    private void Update() {
        if(this.hpSlider.value<this.hpMax&& this.hpSlider.value>0){
            this.hpSlider.value += Time.deltaTime;
        }
        
    }

}
