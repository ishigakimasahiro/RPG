using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_HomingBullet : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfPooledObjects=new List<GameObject>();
    Rigidbody2D rb;
    [SerializeField] GameObject playerBullet;
    float bulletSpeed = 5f;
    float rotateSpeed = 200f;

    [SerializeField] ThisEnemyManager thisEnemyManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 20; i++)
        {
            GameObject Obj = Instantiate(playerBullet, playerBullet.transform);
            Obj.SetActive(false);
            listOfPooledObjects.Add(Obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < listOfPooledObjects.Count; i++)
        {
            if (listOfPooledObjects[i].activeInHierarchy == false)
            {
                return listOfPooledObjects[i];
            }
        }
        return null;
    }

    private void Update()
    {
        Vector2 direction = (Vector2)thisEnemyManager.SetTransformEnemyPosition().position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * bulletSpeed;
    }
}
