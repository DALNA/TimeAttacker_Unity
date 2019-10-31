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
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);

        if (Input.GetMouseButtonDown(0)) //クリックした時、ボールを投げる
        {
            animator.SetBool("OnClick", true);
            BallThrow ();
        }
        else
            animator.SetBool("OnClick", false);
    }

    void BallThrow()
    {
        GameObject newBullet = Instantiate(fireball, ballspawn.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
    }

}
