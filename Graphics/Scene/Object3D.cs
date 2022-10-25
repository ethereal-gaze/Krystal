using OpenTK.Mathematics;

namespace Krystal.Graphics.Scene
{
    public class Object3D
    {
        private float _yaw = 0;
        private float _pitch = 0;
        private float _roll = 0;
        
        public  Vector3 Position { get; set; } = Vector3.Zero;

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(_yaw);
            set => _yaw = MathHelper.DegreesToRadians(value);
        }

        public virtual float Pitch
        {
            get => MathHelper.RadiansToDegrees(_pitch);
            set => _pitch = MathHelper.DegreesToRadians(value);
        }

        public float Roll
        {
            get => MathHelper.RadiansToDegrees(_roll);
            set => _roll = MathHelper.DegreesToRadians(value);
        }

        public Matrix4 Matrix =>
            (Matrix4.CreateTranslation(Position) * Matrix4.CreateRotationZ(Roll) *
             Matrix4.CreateRotationY(Pitch) * Matrix4.CreateRotationX(Yaw));
    } 
}

