using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    enum Position
    {
        left,
        right
    }
    private Position positionStatus = Position.left;
    private Animator animator;

    [SerializeField]
    private float overChangePositionY = 2.0f;
    public Destroy fireball;
    public Transform ballspawn;
    public float P_speed = 5f; //プレイヤースピード
    public float B_power = 1000f; //投げるパワー

    bool bulletAlive = false; //ボールが画面上にあるか

    Vector3 mouseWorldPos;
    Vector3 Player;
    Rigidbody2D rb2d;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //プレイヤー移動
        float horizontal = Input.GetAxisRaw("Horizontal");
        if(positionStatus == Position.right)
        {
            horizontal *= -1;
        }
        transform.Translate(horizontal * P_speed * Time.deltaTime, 0, 0);

        //マウスの位置を取得
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //プレイヤーの位置を取得
        Player = GameObject.FindGameObjectWithTag("Player").transform.position;

        //クリックした時、ボールを投げる
        if (Input.GetMouseButtonDown(0) && !bulletAlive)
        {
            animator.SetBool("OnClick", true);
            BallThrow ();
        }
        else
            animator.SetBool("OnClick", false);

        //マウスの方向に向く
        bool change = false;
        int mag = 0;
        //右
        if (mouseWorldPos.x > Player.x && positionStatus == Position.left)
        {
            mag = 1;
            change = true;
            positionStatus = Position.right;
        }
        //左
        else if (mouseWorldPos.x < Player.x && positionStatus == Position.right)
        {
            mag = 0;
            change = true;
            positionStatus = Position.left;
        }
        if (change)
        {
            transform.rotation = Quaternion.Euler(0, 180 * mag, 0);
        }
    }

    void BallThrow()
    {
        //ボール生成。ボールが画面上にある場合、投げられなくなる。
        var newBullet = Instantiate(fireball, ballspawn.position, Quaternion.identity) as Destroy;
        newBullet.playerMove = this;
        bulletAlive = true;

        //向きを生成
        Vector3 BallDirection = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        //ボール速さ
        newBullet.GetComponent<Rigidbody2D>().velocity = BallDirection * B_power;
    }

    //画面上にボールが無い時、投げられるようになる。
    public void BulletDestroy(Vector3 pos)
    {
        pos.y += overChangePositionY;
        transform.position = pos;
        bulletAlive = false;
    }
}
