using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

[EditorTool(displayName:"PointConection",typeof(ShapPoint))]
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
        Transform targetCustomSnep = ((ShapPoint)target).transform;
        EditorGUI.BeginChangeCheck();
        Vector3 newPos = Handles.PositionHandle(targetCustomSnep.transform.position, Quaternion.identity);
        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetCustomSnep,name = "Lol");
            targetCustomSnep.transform.position = newPos;
        }
    }
    private void ClickNullPosition(Transform targetCustomSnep, Vector3 newPos)
    {
        
    }
}
