using BlastCube.Cubes;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(CubeHandler))]
    public class EditorCubeManager : UnityEditor.Editor
    {
        private CubeHandler targetButton;
        private string powerInputText;
        private Transform blastCubesParent;
        private Transform BlastCubesParent
        {
            get => blastCubesParent ??= targetButton.transform.parent.parent.GetChild(1);
            set => blastCubesParent = value;
        }

        private void OnSceneGUI()
        {
            targetButton = (CubeHandler) target;

            Handles.BeginGUI();
            {
                GUIStyle boxStyle = new GUIStyle("box");

                GUILayout.BeginArea(new Rect(50, 10, 200, 100), boxStyle);
                {
                    GUILayout.Label("Cube Value");

                    powerInputText = GUILayout.TextField(powerInputText, GUILayout.Width(100));

                    GUILayout.Label("Create button");

                    if (GUILayout.Button("Create"))
                    {
                        CubeGenerator cubeGenerator = new CubeGenerator();
                        CubeData cubeData = new CubeData();
                        cubeData.InitializeCubePosition = targetButton.transform.position + Vector3.up;
                        cubeData.CubeValue = int.Parse(powerInputText);
                        //cubeGenerator.GenerateCube(Resources.Load<GameObject>("cube"), cubesModel, BlastCubesParent);
                    }
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }
    }
}