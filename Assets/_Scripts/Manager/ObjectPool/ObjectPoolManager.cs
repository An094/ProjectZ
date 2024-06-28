using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    private GameObject ObjectPoolEmptyHolder;

    private static GameObject ParticleSystemsEmpty;
    private static GameObject GameObjectEmpty;

    public enum PoolType
    {
        ParticleSystem,
        GameObject, 
        None
    }

    public static PoolType PoolingType;

    private void Awake()
    {
        SetupEmpties();
    }

    private void SetupEmpties()
    {
        ObjectPoolEmptyHolder = new GameObject("Pool Objects");

        ParticleSystemsEmpty = new GameObject("Particle Effects");
        ParticleSystemsEmpty.transform.SetParent(ObjectPoolEmptyHolder.transform);

        GameObjectEmpty = new GameObject("GameObjects");
        GameObjectEmpty.transform.SetParent(ObjectPoolEmptyHolder.transform);
    }

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.GameObject)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

        //If the pool doesnt exist, create it
        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

        if (spawnableObj == null)
        {
            GameObject parentObject = SetParentObject(poolType);
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

            if(parentObject!= null)
            {
                spawnableObj.transform.SetParent(parentObject.transform);
            }
        }
        else
        {
            //if there is an inactive object, reactive it
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static GameObject SpawnObject(GameObject objectToSpawn, Transform parentTransform)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

        //If the pool doesnt exist, create it
        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

        if (spawnableObj == null)
        {
            spawnableObj = Instantiate(objectToSpawn, parentTransform);
        }
        else
        {
            //if there is an inactive object, reactive it
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7); // by taking off 7, removing the (Clone) from the name of the passed in obj
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

        if(pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled" + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }    

    private static GameObject SetParentObject(PoolType poolType)
    {
        switch(poolType)
        {
            case PoolType.ParticleSystem:
                return ParticleSystemsEmpty;
            case PoolType.GameObject:
                return GameObjectEmpty;
            case PoolType.None:
                return null;
            default:
                return null;
        }
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
