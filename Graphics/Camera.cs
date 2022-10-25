using System.Reflection;
using Krystal.Graphics.Scene;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Krystal.Graphics;

/// <summary>
/// An abstract representation of the view and projection matrices
/// </summary>
public class Camera : Object3D
{
    private float _fov;
    private float _nearPlane = 0.1f;
    private float _farPlane = 100.0f;
    private float _speed = 1.5f;
    private float _sensetivity;
    private float _pitch;
    
    private Vector2 _aspectRatio = new Vector2(800, 600);

    private Vector3 _front = -Vector3.UnitZ;
    private Vector3 _up = Vector3.UnitY;
    private Vector3 _right = Vector3.UnitX;
    
    Vector2 lastPos = new Vector2(0, 0);

    /// <summary>
    /// Defines the Aspect Ratio. Incorrect values may result in a stretched view.
    /// </summary>
    public Vector2 AspectRatio
    {
        get => _aspectRatio;
        set
        {
            _aspectRatio.X = Math.Clamp(value.X, 1, float.MaxValue);
            _aspectRatio.Y = Math.Clamp(value.Y, 1, float.MaxValue);
        }
    }

    /// <summary>
    /// Defines the field of view.
    /// </summary>
    private float Fov
    {
        get => MathHelper.RadiansToDegrees(_fov);
        set => _fov = MathHelper.DegreesToRadians(MathHelper.Clamp(value, 1.0f, 90.0f));
    }

    /// <summary>
    /// Objects less than this distance from the Camera will be discarded in rendering.
    /// </summary>
    private float NearPlane
    {
        get => _nearPlane;
        set => _nearPlane = Math.Clamp(value, 1, float.MaxValue);
    }

    /// <summary>
    /// Objects more than this distance from the Camera will be discarded in rendering
    /// </summary>
    public float FarPlane
    {
        get => _farPlane;
        set => _farPlane = Math.Clamp(value, 1, float.MaxValue);
    }
    
    /// <summary>
    /// Defines the speed of this camera's keyboard movement.
    /// </summary>
    public float Speed
    {
        get => _speed;
        set => _speed = Math.Clamp(value, 0, float.MaxValue);
    }

    /// <summary>
    /// Defines the pitch of this camera
    /// </summary>
    public override float Pitch
    {
        get => MathHelper.RadiansToDegrees(_pitch);
        set => _pitch =  MathHelper.DegreesToRadians(MathHelper.Clamp(value, -89f, 89f));
    }

    /// <summary>
    /// Defines the sensetivity when looking around.
    /// </summary>
    private float Sensetivity
    {
        get => _sensetivity / 0.01f;
        set => _sensetivity = value * 0.01f;
    }

    /// <summary>
    /// Moves the camera based on the Keyboard state.
    /// </summary>
    /// <param name="keyboardState"></param>
    /// <param name="deltaTime"></param>
    /// <param name="mousePosition"></param>
    public void ProcessFreecamMovement(ref KeyboardState keyboardState, float deltaTime, Vector2 mousePosition)
    {
        if (keyboardState.IsKeyDown(Keys.A))
            Position -= _right * deltaTime * _speed;
        if (keyboardState.IsKeyDown(Keys.D))
            Position += _right * deltaTime * _speed;
        if (keyboardState.IsKeyDown(Keys.W))
            Position += _front * deltaTime * _speed;
        if (keyboardState.IsKeyDown(Keys.S))
            Position -= _front * deltaTime * _speed;
        if (keyboardState.IsKeyDown(Keys.Q))
            Position += _up * deltaTime * _speed;
        if (keyboardState.IsKeyDown(Keys.E))
            Position -= _up * deltaTime * _speed;

        
        var deltaX = mousePosition.X - lastPos.X;
        var deltaY = lastPos.Y - mousePosition.Y ;
        lastPos = mousePosition;

        Yaw += deltaX * _sensetivity;
        Pitch -= deltaY * _sensetivity;
        
        Console.WriteLine("{0} {1}", Pitch, MathHelper.DegreesToRadians(Pitch));
        
        CalculateVectors();
    }

    /// <summary>
    /// Get this camera's Projection Matrix
    /// </summary>
    public Matrix4 FrustumMatrix => Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio.X / AspectRatio.Y,
        _nearPlane, _farPlane);
    
    /// <summary>
    /// This camera's View Matrix
    /// </summary>
    public Matrix4 OrientalMatrix => Matrix4.LookAt(Position, Position + _front, _up);

    /// <summary>
    /// Calculates new vector values based on the Euler angles.
    /// </summary>
    private void CalculateVectors()
    {
        _front.X = MathF.Cos(Pitch) * MathF.Cos(Yaw);
        _front.Y = MathF.Sin(Pitch);
        _front.Z = MathF.Cos(Pitch) * MathF.Sin(Yaw);
        _front = Vector3.Normalize(_front);
        
        _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
        _up = Vector3.Normalize(Vector3.Cross(_right, _front));
    }
    
    public Camera()
    {
        Fov = 65.0f;
        Sensetivity = 1.0f;
    }
}