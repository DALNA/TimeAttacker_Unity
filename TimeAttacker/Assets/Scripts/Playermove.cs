using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    private Animator animator;
    public float speed = 5f; //キャラクタースピード
    public float power = 1000f; //投げるパワー
    public GameObject fireball;
    public Transform ballspawn;
    Rigidbody2D rb2d;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //プレイヤー移動
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);

        //クリックした時、ボールを投げる
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("OnClick", true);
            BallThrow ();
        }
        else
            animator.SetBool("OnClick", false);
    }

    void BallThrow()
    {
        //ボール生成
        GameObject newBullet = Instantiate(fireball, ballspawn.position, Quaternion.identity) as GameObject;

        //クリックした場所の取得
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //向きを生成
        Vector3 BallDirection = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        //ボール速さ
        newBullet.GetComponent<Rigidbody2D>().velocity = BallDirection * power;
    }
}
