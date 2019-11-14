using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float deleteTime = 1.3f;
    public bool isThrow = true;

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    void Update()
    {
        
    }

    //ボールがあるか伝える
    private void OnDestroy()
    {
        var player = GameObject.Find("Player");
        var move = player.GetComponent<Playermove>();
        move.BulletDestroy();
    }
}
