using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isMoving;
    [SerializeField] Animator animator;

    void Update()
    {
        if (isMoving == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if(x!=0)
            {
                y = 0;
            }

            StartCoroutine(Move(new Vector2(x, y)));

            animator.SetBool("isMoving",isMoving);
        }

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
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", 1);
        }
        else
        {
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", -1);
        }
    }

    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        while((targetPos - transform.position).sqrMagnitude>Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

}