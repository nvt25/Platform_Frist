using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeConbat : MonoBehaviour
{
    public int hp;
    private bool isCollider= false;

   public void HpDudcet(){
       if(this.isCollider){
           HpPlayer.instance.HpValueDeduct = this.hp;
       }else{
           return;
       }
   }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            this.isCollider=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            this.isCollider=false;
        }
    }
}
