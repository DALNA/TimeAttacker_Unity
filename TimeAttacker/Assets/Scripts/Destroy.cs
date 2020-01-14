using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float deleteTime = 1.3f;
    public bool isThrow = true;
    public Playermove playerMove { set; private get; }
    private string objtag = "obj";

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
        playerMove.BulletDestroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ボールの当たったポイントを取得
        foreach (ContactPoint2D point in collision.contacts)
        {
            Debug.Log(point.point);
        }

        // 壁や地面に当たった時消える
        if(collision.collider.tag == objtag)
        {
            Destroy(gameObject);
        }
    }
}
