using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levl : MonoBehaviour
{
    public void DefeatCall()
    {
        LevelManager.instance.DefeatGame();
    }

    public void GetFileCall()
    {
        LevelManager.instance.AddFile();
    }

    public void VictoryCall()
    {
        LevelManager.instance.CheckVictory();
    }

}
