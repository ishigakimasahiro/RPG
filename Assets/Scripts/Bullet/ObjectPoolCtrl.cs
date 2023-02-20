using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCtrl : MonoBehaviour
{
    public GameObject pooledObject;
    [SerializeField] List<GameObject> listOfPooledObjects = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(pooledObject,this.transform);
            obj.SetActive(false);
            listOfPooledObjects.Add(obj);
        }
    }

    void Update()
    {
        
    }

    public GameObject GetPooledObject()
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
