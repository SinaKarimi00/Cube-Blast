using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


namespace BlastCube.Cubes
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private CubeData cubeData;
        [SerializeField] private List<TextMeshPro> sideTexts;
        [SerializeField] private bool canPass;
        [SerializeField] private GameObject cubeTrackEffect;

        public List<TextMeshPro> SideTexts => sideTexts;

        public CubeData CubeData
        {
            set => cubeData = value;
            get => cubeData;
        }
        public bool CanPass
        {
            set => canPass = value;
            get => canPass;
        }
        public GameObject CubeTrackEffect => cubeTrackEffect;
    }
}