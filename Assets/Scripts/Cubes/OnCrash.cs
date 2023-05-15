using BlastCube.Base;


namespace BlastCube.Cubes
{
    public class OnCrash : IEvent
    {
        public readonly CubeData shotCubeData;
        public readonly CubeData collisionCubeData;

        public OnCrash(CubeData shotCubeData, CubeData collisionCubeData)
        {
            this.shotCubeData = shotCubeData;
            this.collisionCubeData = collisionCubeData;
        }
    }
}