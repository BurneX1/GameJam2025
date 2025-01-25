using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "New ElemntData", menuName = "Data/02-GameData")]
public class GameData : PersistentScriptableObject
{
    public int dayProgress;




    public override void Reset()
    {
        dayProgress = 0;
       
        base.Reset();
    }
}
