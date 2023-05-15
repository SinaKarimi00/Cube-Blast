using System.Collections.Generic;
using UnityEngine;


namespace BlastCube.Cubes
{
    [CreateAssetMenu(menuName = "Create ColorCubeConfig", fileName = "New ColorCubeConfig")]

    public class ColorCubeConfig : ScriptableObject
    {
        [SerializeField] private List<ColorData> colorsData = new List<ColorData>();

        public Color GetColor(int targetValue)
        {
            ColorData targetColorData = colorsData.Find(x => x.CubeValue == targetValue);
            return targetColorData.CubeColor;
        }
    }
}