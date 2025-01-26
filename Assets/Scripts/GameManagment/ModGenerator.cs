using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ModGenerator : MonoBehaviour
{
    public LevelManager levelManager;

    public GameObject files;
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

        GenerateEnemies();
        GenerateFiles();
    }

    public void GenerateEnemies()
    {
        for (int i = 0; i < moduleValues.Length; i++)
        {
            for(int e = 0; e < moduleValues[i].enemySpawns.Length; e++)
            {
                GameObject enmyObj = Instantiate(enemies[Random.Range(0, enemies.Length)]);
                enmyObj.transform.position = moduleValues[i].enemySpawns[e].transform.position;
            }

        }
    }

    public void GenerateFiles()
    {
        for(int i = 0; i < levelManager.maxFiles; i++)
        {
            bool instantiated = false;
            int value = Random.Range(1, moduleValues.Length - 1);

            while(instantiated==true)
            {
                if (moduleValues[value].fileSpawns.Length <= 0) moduleValues[value].fileSpawned = true;

                if (moduleValues[value].fileSpawned) value++;
                if (value > moduleValues.Length - 1) value = 1;
            }

            CreateFile(moduleValues[value].fileSpawns[Random.Range(0, moduleValues[value].fileSpawns.Length - 1)].transform.position);

            if (levelManager.maxFiles < 7)
            {
                moduleValues[value].fileSpawned = true;
            }
        }

    }

    public void CreateFile(Vector2 position)
    {

        GameObject fileObj = Instantiate(files);
        fileObj.transform.position = position;


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
