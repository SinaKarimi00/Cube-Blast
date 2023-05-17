using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace BlastCube.Cubes
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private CubeData cubeData;
        [SerializeField] private List<TextMeshPro> sideTexts;
        [SerializeField] private bool canPass;
        [SerializeField] private bool collided;
        [SerializeField] private Rigidbody cubeRigidbody;

        public List<TextMeshPro> SideTexts => sideTexts;

        private void Awake()
        {
            cubeRigidbody = GetComponent<Rigidbody>();
        }

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
        public bool Collided
        {
            set => collided = value;
            get => collided;
        }
        public Rigidbody CubeRigidbody => cubeRigidbody;
        public Vector3 CubePosition => transform.position;
        public Transform ParentTransform => transform.parent;
    }
}