using System;
using UnityEngine;


namespace BlastCube.Cubes
{
    [Serializable]
    public struct CubeData
    {
        [SerializeField] private int cubeValue;
        [SerializeField] private int id;
        [SerializeField] private Vector3 initializeCubePosition;

        public int CubeValue
        {
            set => cubeValue = value;
            get => cubeValue;
        }

        public int Id
        {
            set => id = value;
            get => id;
        }

        public Vector3 InitializeCubePosition
        {
            set => initializeCubePosition = value;
            get => initializeCubePosition;
        }
    }
}