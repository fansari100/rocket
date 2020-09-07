using UnityEngine;

/// <summary>
/// Controller for the scrolling star background.
/// </summary>
public class StarField : MonoBehaviour
{
    private const int MAX_STARS = 25;
    private const float STAR_SIZE = 0.3f;
    private const float STAR_SCALE = 0.3f;
    private const float STAR_SPEED = 0.25f;
    private static readonly Color STAR_COLOR = Color.white;

    [SerializeField] private ParticleSystem starField;
    private ParticleSystem.Particle[] stars;

    void Start()
    {
        stars = new ParticleSystem.Particle[MAX_STARS];
        CreateStars();
    }

    void Update()
    {
        MoveStars(-STAR_SPEED);
    }

    /// <summary>
    /// Generates the stars in the star field.
    /// </summary>
    private void CreateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
           stars[i].position = GetRandomPosition();
           stars[i].startSize = GetRandomSize(STAR_SIZE);
           stars[i].startColor = STAR_COLOR;
        }
        starField.SetParticles(stars, stars.Length);
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
        return size * Random.Range(STAR_SCALE, 1f - STAR_SCALE);
    }

    /// <summary>
    /// Moves every star in the star field based on their speed.
    /// </summary>
    /// <param name="speed">The speed of each star.</param>
    public void MoveStars(float speed)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].position += new Vector3(0f, speed * Time.deltaTime, 0f);
            // Recycle stars back to the top of the screen
            if (IsOutOfBounds(stars[i].position))
            {
                Vector3 position = GetRandomPosition();
                stars[i].position = new Vector3(position.x, CameraController.ScreenBounds.y, position.z);
            }
        }
        starField.SetParticles(stars);
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
