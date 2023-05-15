using System.Collections.Generic;
using BlastCube.Cubes;
using BlastCube.Level;
using UnityEditor;
using UnityEngine;


namespace Editor.ConfigCreator
{
    [CustomEditor(typeof(BlastCubesDataHandler))]
    public class BlastCubesDataSaver : UnityEditor.Editor
    {
        private BlastCubesDataHandler blastCubesDataHandler;
        private string levelName;
        private readonly List<int> cubeValues = new List<int>();
        private readonly List<Vector3> cubePositions = new List<Vector3>();

        private void OnSceneGUI()
        {
            blastCubesDataHandler = (BlastCubesDataHandler) target;
            Handles.BeginGUI();
            {
                GUIStyle boxStyle = new GUIStyle("box");

                GUILayout.BeginArea(new Rect(50, 10, 200, 150), boxStyle);
                {
                    if (GUILayout.Button("Get blast cubes"))
                    {
                        for (int i = 0; i < blastCubesDataHandler.transform.childCount; i++)
                        {
                            cubeValues.Add(blastCubesDataHandler.transform.GetChild(i).GetComponent<BlastCube.Cubes.Cube>().CubeData.CubeValue);
                            cubePositions.Add(blastCubesDataHandler.transform.GetChild(i).transform.position);
                        }
                    }

                    GUILayout.Label("Level Name");

                    levelName = GUILayout.TextField(levelName, GUILayout.Width(100));

                    GUILayout.Label("Level Config");

                    if (GUILayout.Button("Save Lands Data"))
                    {
                        if (Resources.Load($"LevelConfigs/{levelName}"))
                        {
                            LevelConfig levelConfig = Resources.Load<LevelConfig>($"LevelConfigs/{levelName}");
                            AddToConfig(levelConfig: levelConfig);
                        }
                        else
                        {
                            LevelConfig newLevelConfig = ScriptableObject.CreateInstance<LevelConfig>();
                            AddToConfig(levelConfig: newLevelConfig);
                            AssetDatabase.CreateAsset(newLevelConfig, $"Assets/Resources/LevelConfigs/{levelName}.asset");
                        }
                    }
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }

        private void AddToConfig(LevelConfig levelConfig)
        {

            for (int i = 0; i < cubeValues.Count; i++)
            {
                CubeData cubeData = new CubeData();
                cubeData.CubeValue = cubeValues[i];
                cubeData.InitializeCubePosition = cubePositions[i];
                levelConfig.Cubes.Add(cubeData);
            }
        }
    }
}