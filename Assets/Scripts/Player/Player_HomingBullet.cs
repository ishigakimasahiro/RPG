using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_HomingBullet : MonoBehaviour
{
    [SerializeField] ThisEnemyManager target;
    Rigidbody2D rb;
    float bulletSpeed = 5f;
    float rotateSpeed = 200f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Vector2 direction = (Vector2)target.SetTransformEnemyPosition().position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * bulletSpeed;
    }
}
