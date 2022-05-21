using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Child Object")]
    [SerializeField] private GameObject panelMenu;
    [Header("Bool")]
    private bool isMenu;
    protected virtual void Awake() {
        this.LoadChildObjects();
    }

    void Update()
    {
        // Debug.Log(this.isMenu);
        this.ShowUi();
        this.CheckIsGameover();
    }
    void Reset(){
        this.LoadChildObjects();
    }
    protected virtual void LoadChildObjects(){
        this.panelMenu = transform.Find("Panel").gameObject;
    }
    protected virtual void CheckIsGameover()
    {
        this.isMenu = GameManager.instance.IsGameOver;
    }
    protected virtual void ShowUi()
    {
        this.panelMenu.SetActive(this.isMenu);
    }

}
