using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum PlayerType
    {
        STOP,
        LEFT,
        RIGHT
    }

    PlayerType playerType = PlayerType.STOP;

    bool isMoving;
    [SerializeField] Animator animator;

    [SerializeField] LayerMask SolidObjectsLayer;

    private Rigidbody2D rb;
    private float x_val;
    private float playerSpeed;
    public float inputSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        x_val = Input.GetAxis("Horizontal");

        //待機
        if (x_val == 0)
        {
            playerType = PlayerType.STOP;
        }
        //右に移動
        else if (x_val > 0)
        {
            playerType = PlayerType.RIGHT;
        }
        //左に移動
        else if (x_val < 0)
        {
            playerType = PlayerType.LEFT;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
    void FixedUpdate()
    {
        isMoving = false;

        switch(playerType)
        {
            case PlayerType.STOP:
                playerSpeed = 0;
                break;
            case PlayerType.RIGHT:
                playerSpeed = inputSpeed;
                MoveSet();
                break;
            case PlayerType.LEFT:
                playerSpeed = inputSpeed * -1;
                MoveSet();
                break;
        }

        // キャラクターを移動 Vextor2(x軸スピード、y軸スピード(元のまま))
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);

        animator.SetBool("isMoving", isMoving);
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
        else
        {
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", -1);
        }
    }

}
