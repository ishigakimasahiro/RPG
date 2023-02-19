using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isMoving;
    [SerializeField] Animator animator;

    [SerializeField] LayerMask SolidObjectsLayer;

    private Rigidbody2D rb;
    private float x_val;
    private float speed;
    public float inputSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        x_val = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        isMoving = false;

        //待機
        if (x_val == 0)
        {
            speed = 0;
        }
        //右に移動
        else if (x_val > 0)
        {
            speed = inputSpeed;
            MoveSet();
        }
        //左に移動
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            MoveSet();
        }

        // キャラクターを移動 Vextor2(x軸スピード、y軸スピード(元のまま))
        rb.velocity = new Vector2(speed, rb.velocity.y);

        CheckForEncounters();
    }

    void MoveSet()
    {
        isMoving = true;

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                animator.SetFloat("InputX", 1f);
                animator.SetFloat("InputY", 0);
            }
            else
            {
                animator.SetFloat("InputX", -1f);
                animator.SetFloat("InputY", 0);
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position,0.2f, SolidObjectsLayer))
        {
            if(Random.Range(0,100)<6)
            {
                Debug.Log("モンスターに遭遇");
            }
        }
    }

}
