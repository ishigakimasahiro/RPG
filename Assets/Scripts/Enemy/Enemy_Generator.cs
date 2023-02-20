using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{

    [SerializeField] List<GameObject> listOfEnemyObjects = new List<GameObject>();
    [SerializeField] GameObject enemyObject;
    [SerializeField] int enemyNumber;

    void Start()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            GameObject Obj = Instantiate(enemyObject, enemyObject.transform);
            Obj.SetActive(false);
            listOfEnemyObjects.Add(Obj);
        }
    }

    public GameObject GetEnemyGameObjects()
    {
        for (int i = 0; i < listOfEnemyObjects.Count; i++)
        {
            if (listOfEnemyObjects[i].activeInHierarchy == false)
            {
                return listOfEnemyObjects[i];
            }
        }
        return null;
    }
}
