using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModGenerator : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject[] enemies;

    public ModulePack[] modules;

    public ModuleStats[] moduleValues;

    // Start is called before the first frame update
    void Start()
    {
       
        GenerateSpace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateSpace()
    {
        for(int i = 0; i < modules.Length; i++)
        {
            GameObject modObj = Instantiate(modules[i].prefsList[Random.Range(0, modules[i].prefsList.Length)]);
            modObj.transform.position = modules[i].spawnPoint.position;

            ModuleStats stats = modObj.GetComponent<ModuleStats>();

            if (stats != null) AddStatsToArray(stats, ref moduleValues);


        }

    }

    public void GenerateEnemies()
    {
        for (int i = 0; i < moduleValues.Length; i++)
        {
            foreach(GameObject obj in moduleValues[i].enemySpawns)
            {
                GameObject enmyObj = Instantiate(enemies[Random.Range(0, enemies.Length)]);
                enmyObj.transform.position = obj.transform.position;

                ModuleStats stats = enmyObj.GetComponent<ModuleStats>();
            }


        }
    }

    public void GenerateFiles()
    {
        if (levelManager.maxFiles > moduleValues.Length)
        {

        }
        else
        {

        }
    }

    public void AddStatsToArray(ModuleStats sts, ref ModuleStats[] array)
    {
        ModuleStats[] objList = { sts };
        if (array == null) array = objList;
        else
        {
            array = array.Concat(objList).ToArray();
        }
        Debug.Log(array);
    }
}
[System.Serializable]
public class ModulePack
{
    public Transform spawnPoint;

    public GameObject[] prefsList;
}
