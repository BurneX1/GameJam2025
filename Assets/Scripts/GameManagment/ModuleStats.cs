using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ModuleStats : MonoBehaviour
{
    public bool fileSpawned;

    public GameObject[] fileSpawns;
    public GameObject[] enemySpawns;
    public GameObject[] secondarySpawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillObjects()
    {
        Debug.Log("Invoke Fill");
        foreach(Transform obj in GetComponentsInChildren<Transform>())
        {
            if (obj.CompareTag("FileSpawn")) AddObjToArray(obj.gameObject, ref fileSpawns);
            if (obj.CompareTag("EnemySpawn")) AddObjToArray(obj.gameObject, ref enemySpawns);
            if (obj.CompareTag("ScndEnmSpwn")) AddObjToArray(obj.gameObject, ref secondarySpawns);
        }
    }

    public void AddObjToArray(GameObject obj, ref GameObject[] array)
    {
        GameObject[] objList = { obj };
        if (array==null) array = objList;
        else
        {
            array = array.Concat(objList).ToArray();
        }
        Debug.Log(array);
    }
}
