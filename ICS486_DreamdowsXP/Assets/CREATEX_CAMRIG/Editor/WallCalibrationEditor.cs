using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
using UnityEngine.UI; 

[CustomEditor(typeof(WallCalibrationController))]
public class WallCalibrationEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        WallCalibrationController wallcontrol = (WallCalibrationController)target;
        EditorStyles.label.wordWrap = true;
        EditorGUILayout.LabelField("Wall Calibration", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("To callibrate the camera matrix:"); 
        EditorGUILayout.LabelField("The x value of this game object's scale must be equal to the real height of the target wall in meters");
        EditorGUILayout.LabelField("The y value of this game object's scale must be equal to the real width of the target wall in meters");

        if(GUILayout.Button("Reset to Create(X) default values"))
        {
            wallcontrol.gameObject.GetComponent<WallCalibrationController>().ResetToDefault();
        }
    }
}
