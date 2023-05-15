using UnityEngine;


namespace BlastCube.Cubes
{
    public class ColorCubeHandler
    {
        private readonly ColorCubeConfig colorCubeConfig;

        public ColorCubeHandler()
        {
            colorCubeConfig = Resources.Load<ColorCubeConfig>("ColorConfig");
        }

        public Color CalculateColor(int targetValue)
        {
            int maxValue = 2048;
            if (targetValue > maxValue)
                targetValue /= maxValue;

            return colorCubeConfig.GetColor(targetValue);
        }

        public void SetColor(Color calculatedColor, GameObject targetCube)
        {
            targetCube.GetComponent<Renderer>().material.color = calculatedColor;
        }
    }
}