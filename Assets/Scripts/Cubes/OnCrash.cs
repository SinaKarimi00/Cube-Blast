using BlastCube.Base;


namespace BlastCube.Cubes
{
    public class OnCrash : IEvent
    {
        public readonly Cube shotCube;
        public readonly Cube collisionCube;

        public OnCrash(Cube shotCube, Cube collisionCube)
        {
            this.shotCube = shotCube;
            this.collisionCube = collisionCube;
        }
    }
}