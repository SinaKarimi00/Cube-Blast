using System.Collections.Generic;
using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "New LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int gridWidth;
        [SerializeField] private int gridHeight;
        [SerializeField] private List<CubeData> cubes = new List<CubeData>();
        public int GridWidth
        {
            get => gridWidth;
            set => gridWidth = value;
        }
        public int GridHeight
        {
            get => gridHeight;
            set => gridHeight = value;
        }
        public List<CubeData> Cubes
        {
            get => cubes;
            set => cubes = value;
        }
    }
}