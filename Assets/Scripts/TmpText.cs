using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TmpText : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float vectorX;
    void Awake()
    {
        this.textMesh = GetComponent<TextMeshPro>();
    }
    private void Start() {
        Destroy(gameObject,0.5f);
        this.vectorX = Random.Range(-1.5f,1.5f);
    }
    void Update()
    {
        transform.position +=  new Vector3(this.vectorX,0.8f) * Time.deltaTime;
    }
    public void setUp(int damage,bool isDeadly){
        this.textMesh.SetText(damage.ToString());
        if(isDeadly){
            this.textMesh.color = Color.red;
        }else{
            this.textMesh.color = Color.yellow;
        }
    }
}
