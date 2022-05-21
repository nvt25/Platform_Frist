using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver;
    private void Awake(){
        if(GameManager.instance != null) Debug.Log("Error");
        GameManager.instance = this;
    }
    //Begin Set get
    public bool IsGameOver 
    { 
        get
        {
            return this.isGameOver;
        } 
        set
        {
            this.isGameOver = value;
        } 
    }
    //End Set Get
}
