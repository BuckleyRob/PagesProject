using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Lift))]
public class LiftInspector : Editor {
    //public override void OnInspectorGUI(){
    //    serializedObject.Update();
    //    EditorGUILayout.PropertyField(serializedObject.FindProperty("stops"), true);
    //    serializedObject.ApplyModifiedProperties();
    //}
    private Lift lift;
    private void OnSceneGUI(){
        lift = target as Lift;
        Vector3[] stops = lift.stops;
        for(int i = 0; i< stops.Length -1; i++) {
            Handles.DrawLine(stops[i],stops[i + 1]);
            DrawHandle(i);
        }
        DrawHandle(stops.Length - 1);
    }

    private void DrawHandle(int i){
        EditorGUI.BeginChangeCheck();
        Vector3 pos = Handles.DoPositionHandle(lift.stops[i], Quaternion.identity);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(lift, "Move Point");
            EditorUtility.SetDirty(lift);
            lift.stops[i] = pos;
        }
    }
}
