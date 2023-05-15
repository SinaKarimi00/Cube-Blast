using BlastCube.Level;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(GridHandler))]
    public class EditorGridCManager : UnityEditor.Editor
    {
        private string widthInput;
        private string heightInput;
        private string levelName;

        private void OnSceneGUI()
        {
            Handles.BeginGUI();
            {
                GUIStyle boxStyle = new GUIStyle("box");

                GUILayout.BeginArea(new Rect(50, 10, 200, 220), boxStyle);
                {
                    GUILayout.Label("width");

                    widthInput = GUILayout.TextField(widthInput, GUILayout.Width(100));

                    GUILayout.Label("height");

                    heightInput = GUILayout.TextField(heightInput, GUILayout.Width(100));

                    GUILayout.Label("Create");

                    if (GUILayout.Button("Create Cube"))
                    {
                        CreateGrid(int.Parse(widthInput), int.Parse(heightInput));
                        PlayerPrefs.SetString("GridWidth", widthInput);
                        PlayerPrefs.SetString("GridHeight", heightInput);
                    }
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }

        private void CreateGrid(int width, int height)
        {
            GameObject levelBase = Object.Instantiate(Resources.Load<GameObject>("Levels/BaseLevel"));
            LevelFrame levelFrameComponent = levelBase.GetComponent<LevelFrame>();
            Transform landsTransform = levelFrameComponent.LandsParent;
            int middleOfWidth = width / 2;
            int middleOfHeight = height / 2;
            GameObject landPrefab = Resources.Load<GameObject>("land");
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GameObject generatedLand = Object.Instantiate(landPrefab, new Vector3(x, 0f, z), Quaternion.identity, landsTransform);

                    if (x == middleOfWidth && z == middleOfHeight)
                    {
                        ColliderManager(generatedLand, width, height);
                    }
                }
            }
        }

        private void ColliderManager(GameObject generatedLand, int width, int height)
        {
            BoxCollider collider = generatedLand.GetComponent<BoxCollider>();
            collider.enabled = true;
            collider.size = new Vector3(width, 1, height);
        }
    }
}