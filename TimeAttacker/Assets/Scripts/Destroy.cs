using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float deleteTime = 1.3f;
    public Playermove playerMove { set; private get; }
    public string objtag = "obj";

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
        playerMove.BulletDestroy(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁や地面に当たった時消える
        if (collision.collider.tag == objtag)
        {
            Destroy(gameObject);
        }
    }
}
