using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_s : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;

        transform.position = new Vector3(playerPos.x, 0, -10);
    }
}
