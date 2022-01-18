namespace Entities.Boat
{
    public struct BoatRotationChange
    {
        public float RotationAngle { get; }

        public BoatRotationChange(float rotationAngle)
        {
            RotationAngle = rotationAngle;
        }
    }
}