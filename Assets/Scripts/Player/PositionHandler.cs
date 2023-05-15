using UnityEngine;


namespace BlastCube.Player
{

    public class PositionHandler
    {
        private readonly Camera mainCamera;

        public PositionHandler(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }

        public Vector3 GetCurrentPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
            float distance;
            xy.Raycast(ray, out distance);
            return ray.GetPoint(distance);
        }
    }
}