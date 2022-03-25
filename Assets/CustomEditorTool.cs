using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

[EditorTool(displayName:"PointConection",typeof(AuxiliaryScript))]
public class CustomEditorTool : EditorTool
{
    [SerializeField] private Texture2D toolIcon;
    public override GUIContent toolbarIcon
    {
        get
        {
            return new GUIContent
            {
                image = toolIcon,
                text = "Custom Point Conection",
                tooltip = "Costum Swap Point Conection"
            };
        }
    }
    public override void OnToolGUI(EditorWindow window)
    {
        Transform targetCustomSnep = ((AuxiliaryScript)target).transform;
        EditorGUI.BeginChangeCheck();
        Vector3 newPos = Handles.PositionHandle(targetCustomSnep.transform.position, Quaternion.identity);
        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetCustomSnep,name = "Lol");
            ClickNullPosition(targetCustomSnep,newPos); 
        }
    }
    private void ClickNullPosition(Transform targetCustomSnep, Vector3 newPos)
    {
        CoustomPoint[] allPoint = FindObjectsOfType<CoustomPoint>();
        CoustomPoint[] targetPoints = targetCustomSnep.GetComponents<CoustomPoint>();
        Vector3 bestposition = newPos;
        float closesDistance = float.PositiveInfinity;
        foreach(CoustomPoint point in allPoint)
        {
            if (point.transform.parent == targetCustomSnep) continue;
            foreach(CoustomPoint ownPoint in targetPoints)
            {
                Vector3 targetPos = point.transform.position - (ownPoint.transform.position - targetCustomSnep.position);
                float distance = Vector3.Distance(targetPos, newPos);
                if(distance < closesDistance)
                {
                    closesDistance = distance;
                    bestposition = targetPos; 
                }
            }
        }
        if(closesDistance < 0.5f)
        {
            targetCustomSnep.position = bestposition;
        }
        else
        {
            targetCustomSnep.position = newPos;
        }
    }
}
