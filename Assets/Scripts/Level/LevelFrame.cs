using UnityEngine;


namespace BlastCube.Level
{
    public class LevelFrame : MonoBehaviour
    {
        [SerializeField] private Transform landsParent;
        [SerializeField] private Transform blastCubesParent;
        [SerializeField] private Transform leftWallParent;
        [SerializeField] private Transform rightWallParent;
        [SerializeField] private Transform frontWallParent;

        public Transform LandsParent => landsParent;
        public Transform BlastCubesParent => blastCubesParent;
        public Transform LeftWallParent => leftWallParent;
        public Transform RightWallParent => rightWallParent;
        public Transform FrontWallParent => frontWallParent;
    }
}