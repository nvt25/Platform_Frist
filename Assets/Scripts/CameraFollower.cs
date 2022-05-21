using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    [Header("Ngung di chuyen")]
    public float min,max;
    void LateUpdate()
    {
        Vector3 tempPos = transform.position;
        tempPos.x = this.player.position.x;
        if(tempPos.x < min) tempPos.x = min;
        if(tempPos.x > max) tempPos.x = max;
        transform.position = tempPos;
    }
}
