using System;
using UnityEngine;


namespace BlastCube.Cubes
{
    [Serializable]
    public struct ColorData
    {
        [SerializeField] private int cubeValue;
        [SerializeField] private Color cubeColor;

        public int CubeValue => cubeValue;
        public Color CubeColor => cubeColor;
    }
}