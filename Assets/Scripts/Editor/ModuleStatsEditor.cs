using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ModuleStats))]
public class ModuleStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ModuleStats module = (ModuleStats)target;
        if (GUILayout.Button("Fill"))
        {
            module.FillObjects();
        }
    }
}
