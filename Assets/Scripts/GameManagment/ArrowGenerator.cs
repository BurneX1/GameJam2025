using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject ArrowPref;
    public ArrowGenerator instance;
    private void Awake()
    {
        instance = this;
    }

    public void GenerateArrow(Transform target)
    {
        
    }
}
