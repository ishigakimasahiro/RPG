using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_BulletGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfPooledObjects = new List<GameObject>();
    [SerializeField] GameObject playerBullet;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject _enemyPrefab = Instantiate(playerBullet, this.transform);
            _enemyPrefab.SetActive(false);
            listOfPooledObjects.Add(_enemyPrefab);
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

}
