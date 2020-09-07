using UnityEngine;

/// <summary>
/// Controller for the scrolling star background.
/// </summary>
public class _StarField : MonoBehaviour
{
    private const int MaxStars = 25;
    private const float StarSize = 0.3f;
    private const float StarScale = 0.3f;
    private const float StarSpeed = 0.25f;
    private static readonly Color StarColor = Color.white;

    [SerializeField] private ParticleSystem _starField;
    private ParticleSystem.Particle[] _stars;

    void Start()
    {
        _stars = new ParticleSystem.Particle[MaxStars];
        CreateStars();
    }

    void Update()
    {
        MoveStars(-StarSpeed);
    }

    /// <summary>
    /// Generates the stars in the star field.
    /// </summary>
    private void CreateStars()
    {
        for (int i = 0; i < _stars.Length; i++)
        {
           _stars[i].position = GetRandomPosition();
           _stars[i].startSize = GetRandomSize(StarSize);
           _stars[i].startColor = StarColor;
        }
        _starField.SetParticles(_stars, _stars.Length);
    }

    /// <summary>
    /// Gets a random position within the screen's bounds.
    /// </summary>
    /// <returns>A random position within the screen's bounds.</returns>
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-CameraController.ScreenBounds.x, CameraController.ScreenBounds.x);
        float y = Random.Range(-CameraController.ScreenBounds.y, CameraController.ScreenBounds.y);
        return new Vector3(x, y, transform.position.z);
    }

    /// <summary>
    /// Gets a new star size from a base star size and random scaling.
    /// </summary>
    /// <param name="size">The base star size.</param>
    /// <returns>The scaled size of the base star size.</returns>
    private float GetRandomSize(float size)
    {
        return size * Random.Range(StarScale, 1f - StarScale);
    }

    /// <summary>
    /// Moves every star in the star field based on their speed.
    /// </summary>
    /// <param name="speed">The speed of each star.</param>
    public void MoveStars(float speed)
    {
        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].position += new Vector3(0f, speed * Time.deltaTime, 0f);
            // Recycle stars back to the top of the screen
            if (IsOutOfBounds(_stars[i].position))
            {
                Vector3 position = GetRandomPosition();
                _stars[i].position = new Vector3(position.x, CameraController.ScreenBounds.y, position.z);
            }
        }
        _starField.SetParticles(_stars);
    }

    /// <summary>
    /// Checks if a background object's position is out of the screen's lower bound.
    /// </summary>
    /// <param name="position">The object's position.</param>
    /// <returns>True if out of bounds. False if not out of bounds.</returns>
    private bool IsOutOfBounds(Vector3 position)
    {
        return position.y < -CameraController.ScreenBounds.y;
    }
}
