using BlastCube.Cubes;
using BlastCube.Level;
using UnityEditor;
using UnityEngine;


namespace Editor.ConfigCreator
{
    [CustomEditor(typeof(GridDataHandler))]
    public class GridDataSaver : UnityEditor.Editor
    {
        private GridDataHandler gridDataHandler;
        private string levelName;

        private void OnSceneGUI()
        {
            gridDataHandler = (GridDataHandler) target;
            Handles.BeginGUI();
            {
                GUIStyle boxStyle = new GUIStyle("box");

                GUILayout.BeginArea(new Rect(50, 10, 200, 150), boxStyle);
                {
                    string gridWidth = PlayerPrefs.GetString("GridWidth");
                    string gridHeight = PlayerPrefs.GetString("GridHeight");
                    GUILayout.Label($"W: {gridWidth}");

                    GUILayout.Label($"H: {gridHeight}");

                    GUILayout.Label("Level Name");

                    levelName = GUILayout.TextField(levelName, GUILayout.Width(100));

                    GUILayout.Label("Level Config");

                    if (GUILayout.Button("Save Lands Data"))
                    {
                        if (Resources.Load($"LevelConfigs/{levelName}"))
                        {
                            LevelConfig levelConfig = Resources.Load<LevelConfig>($"LevelConfigs/{levelName}");
                            levelConfig.GridHeight = int.Parse(gridHeight);
                            levelConfig.GridWidth = int.Parse(gridWidth);
                        }
                        else
                        {
                            LevelConfig newLevelConfig = ScriptableObject.CreateInstance<LevelConfig>();
                            newLevelConfig.GridHeight = int.Parse(gridHeight);
                            newLevelConfig.GridWidth = int.Parse(gridWidth);
                            AssetDatabase.CreateAsset(newLevelConfig, $"Assets/Scripts/Level/Resources/LevelConfigs/{levelName}.asset");
                        }
                    }
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }
    }
}