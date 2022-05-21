using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isStop;
    public GameObject resume;
    public void Pause(){
        this.isStop = true;
        GameManager.instance.IsGameOver = true;
    }
    public void Resume(){
        this.isStop = false;
        GameManager.instance.IsGameOver = false;
    }

    void Update()
    {
        this.Stop();
    }
    private void Stop(){
        if(HpPlayer.instance.isDie){
            this.isStop= true;
            this.resume.SetActive(false);
        }
        if(this.isStop){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }
    public void NewGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
