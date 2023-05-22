using System;
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
        [SerializeField] private TrailRenderer trail;
        [SerializeField] private GameObject cubeTrackEffect;
        [SerializeField] private LineRenderer cubeLineRenderer;

        private void Awake()
        {
            cubeLineRenderer = GetComponent<LineRenderer>();
            cubeRigidbody = GetComponent<Rigidbody>();
        }
        

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
        public bool Collided
        {
            set => collided = value;
            get => collided;
        }
        public TrailRenderer GetTrail() => trail;
        public Rigidbody GetCubeRigidbody() => cubeRigidbody;
        public Rigidbody CubeRigidbody => cubeRigidbody;
        public Vector3 CubePosition => transform.position;
        public Transform ParentTransform => transform.parent;
        public LineRenderer CubeLineRenderer => cubeLineRenderer;
        public GameObject CubeTrackEffect => cubeTrackEffect;
    }
}