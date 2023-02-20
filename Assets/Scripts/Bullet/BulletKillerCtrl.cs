using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillerCtrl : MonoBehaviour
{
    [SerializeField] string TagName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TagName)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
