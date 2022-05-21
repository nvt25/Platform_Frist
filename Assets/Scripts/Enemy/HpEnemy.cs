using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpEnemy : MonoBehaviour
{
    public Slider slider;
    public Color hpLow;
    public Color hpHigh;
    public Vector3 offset;

    void Start()
    {
        slider.gameObject.SetActive(false);
    }
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+this.offset);
    }
    public void setHpEnemy(float hp,float maxHp){
        slider.gameObject.SetActive(true);
        slider.value = hp;
        slider.maxValue = maxHp;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(this.hpLow, this.hpHigh,slider.normalizedValue);
    }
}
