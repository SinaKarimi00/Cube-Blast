using BlastCube.Cubes;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(CubeLabels))]
    public class EditorPositionLabel : UnityEditor.Editor
    {
        private CubeLabels targetGameObject;
        private GUIStyle textStyle;

        private GUIStyle TextStyle
        {
            get => textStyle ??= new GUIStyle();
            set => textStyle = value;
        }

        private void OnSceneGUI()
        {
            targetGameObject = (CubeLabels) target;
            TextStyle.fontSize = 20;
            TextStyle.normal.textColor = Color.white;
            TextStyle.alignment = TextAnchor.MiddleCenter;
            Handles.Label(targetGameObject.transform.position + Vector3.down * 2f, targetGameObject.transform.position.ToString());
        }
    }
}