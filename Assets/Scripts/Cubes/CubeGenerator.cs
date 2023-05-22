using UnityEngine;
using Object = UnityEngine.Object;


namespace BlastCube.Cubes
{
    public class CubeGenerator
    {
        private Cube cubeComponent;

        public Cube GenerateCube(GameObject cubeGameObject, CubeData baseCubeData, Transform parentTransform)
        {
            GameObject cubeObject = Object.Instantiate(cubeGameObject, baseCubeData.InitializeCubePosition, Quaternion.identity, parentTransform);
            cubeComponent = cubeObject.GetComponent<Cube>();

            RecordCubeData(baseCubeData);
            TextCubeHandler textCubeHandler = new TextCubeHandler();
            textCubeHandler.WriteValueOnCube(cubeComponent.SideTexts, cubeComponent.CubeData.CubeValue);
            return cubeObject.GetComponent<Cube>();
        }


        private void RecordCubeData(CubeData baseCubeData)
        {
            baseCubeData.Id = CubesDataHandler.GetId();
            cubeComponent.CubeData = baseCubeData;
            CheckValue(cubeComponent.CubeData);
            ColorCubeHandler colorCubeHandler = new ColorCubeHandler();
            colorCubeHandler.SetColor(colorCubeHandler.CalculateColor(cubeComponent.CubeData.CubeValue),cubeComponent.gameObject);
            CubesDataHandler.SaveCubeData(cubeComponent);
        }

        private void CheckValue(CubeData cubeData)
        {
            if (cubeComponent.CubeData.CubeValue == 0)
            {
                CubeValueGenerator cubeValueGenerator = new CubeValueGenerator();
                cubeData.CubeValue = cubeValueGenerator.GetNewValue();
                cubeComponent.CubeData = cubeData;
            }
        }
    }
}