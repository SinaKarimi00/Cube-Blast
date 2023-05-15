using System.Collections.Generic;
using TMPro;


namespace BlastCube.Cubes
{
    public class TextCubeHandler
    {
        public void WriteValueOnCube(List<TextMeshPro> sideTexts, int cubeValue)
        {
            string textValue = GenerateText();

            foreach (TextMeshPro item in sideTexts)
                item.text = textValue;

            string GenerateText()
            {
                if (cubeValue > 1000)
                    return textValue = cubeValue / 1000 + " K";

                return textValue = cubeValue.ToString();
            }
        }
    }
}