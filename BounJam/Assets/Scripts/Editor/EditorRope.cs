using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseRope), true)]
public class EditorRope : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("ResetRope"))
        {
            ((BaseRope)target).RopeStart();
        }

        EditorGUI.EndDisabledGroup();
    }
}
