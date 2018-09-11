using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

   
    private List<GameObject> pooledObjects;
   
    public GameObject poolObject;
    
    public int poolQuantity;
    
    void Start()
    {
        //pooledObjects = new List<GameObject>();
        //for (int i = 0; i < poolQuantity; i++)
        //{
        //    GameObject obj = Instantiate(poolObject) as GameObject;
        //    obj.SetActive(false);
        //    pooledObjects.Add(obj);
        //}
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i] == null)
            {
                GameObject obj = Instantiate(poolObject) as GameObject;
                obj.SetActive(false);
                pooledObjects[i] = obj;
                return pooledObjects[i];
            }
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
 

        return null;
    }

}


