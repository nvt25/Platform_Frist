using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFollowPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speedBullet;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player_1");
    }

    // Update is called once per frame
    void Update()
    {
        this.followPlayer();
    }
    private void followPlayer(){
        Vector3 targetPosition = this.player.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPosition,this.speedBullet*Time.deltaTime);
        transform.Rotate(new Vector3(0,0,10));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            HpPlayer.instance.HpValueDeduct = 5;
            Destroy(gameObject);
        }
    }
}
