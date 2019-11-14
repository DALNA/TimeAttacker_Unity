using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    private Animator animator;

    public GameObject fireball;
    public Transform ballspawn;
    public float P_speed = 5f; //プレイヤースピード
    public float B_power = 1000f; //投げるパワー

    bool bulletAlive = false; //ボールが画面上にあるか

    Vector3 mouseWorldPos;
    Rigidbody2D rb2d;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //プレイヤー移動
        transform.Translate(Input.GetAxisRaw("Horizontal") * P_speed * Time.deltaTime, 0, 0);

        //マウスの位置を取得
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //クリックした時、ボールを投げる
        if (Input.GetMouseButtonDown(0) && !bulletAlive)
        {
            animator.SetBool("OnClick", true);
            BallThrow ();
        }
        else
            animator.SetBool("OnClick", false);
    }

    void BallThrow()
    {
        //ボール生成。ボールが画面上にあるので、投げられなくなる。
        GameObject newBullet = Instantiate(fireball, ballspawn.position, Quaternion.identity) as GameObject;
        bulletAlive = true;

        //向きを生成
        Vector3 BallDirection = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        //ボール速さ
        newBullet.GetComponent<Rigidbody2D>().velocity = BallDirection * B_power;
    }

    //ボールが消えた時、投げられるようになる。
    public void BulletDestroy()
    {
        bulletAlive = false;
    }
}
