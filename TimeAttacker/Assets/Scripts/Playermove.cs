using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    private Animator animator;
    public float P_speed = 5f; //キャラクタースピード
    public float B_power = 1000f; //投げるパワー
    public bool isThrow = true;
    public Transform ballspawn;
    Rigidbody2D rb2d;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void checkthrow()
    {
        if (fireball) isThrow = false;
        else isThrow = true;
    }

    void Update()
    {
        //プレイヤー移動
        transform.Translate(Input.GetAxisRaw("Horizontal") * P_speed * Time.deltaTime, 0, 0);

        //クリックした時、ボールを投げる
        if (Input.GetMouseButtonDown(0) && isThrow == true)
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
        newBullet.GetComponent<Rigidbody2D>().velocity = BallDirection * B_power;
    }
}
