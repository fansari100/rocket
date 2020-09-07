using UnityEngine;
using UnityEngine.U2D;

public class BackgroundPlanet : MonoBehaviour
{
    private const float PlanetSpeed = 0.5f;
    private const float HalfSpriteSize = 256f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteAtlas spriteAtlas;

    private Sprite[] _sprites;
    private int _currentSprite;
    private Vector3 _direction;
    private float _spriteWidthOffset;
    private float _spriteHeightOffset;

    void Start()
    {
        _currentSprite = -1;
        _sprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(_sprites);
        ConfigurePlanet();
    }

    void Update()
    {
        Move(PlanetSpeed);
    }

    /// <summary>
    /// Configures a random sprite, position, and direction for the planet.
    /// </summary>
    private void ConfigurePlanet()
    {
        _currentSprite = GetRandomSprite();
        spriteRenderer.sprite = _sprites[_currentSprite];
        _direction = GetRandomDirection();
        _spriteWidthOffset = spriteRenderer.sprite.rect.width / HalfSpriteSize;
        _spriteHeightOffset = spriteRenderer.sprite.rect.height / HalfSpriteSize;
        transform.position = GetRandomPosition();
    }

    /// <summary>
    /// Gets a random direction from 1 of the 4 intercardinal directions.
    /// </summary>
    /// <returns>A vector with x and y values of either -1f or 1f.</returns>
    private Vector3 GetRandomDirection()
    {
        float x = Random.value > 0.5f ? -1f : 1f;
        float y = Random.value > 0.5f ? -1f : 1f;
        return new Vector3(x, y, 0f);
    }

    /// <summary>
    /// Gets a random index in the class's Sprite array that is not the current index.
    /// </summary>
    /// <returns>An index in the class's Sprite array.</returns>
    private int GetRandomSprite()
    {
        int nextSprite = Random.Range(0, _sprites.Length);
        while (nextSprite == _currentSprite)
        {
            nextSprite = Random.Range(0, _sprites.Length);
        }
        return nextSprite;
    }

    /// <summary>
    /// Gets a random position outside of the screen's bounds.
    /// </summary>
    /// <returns>A position vector offset by the current sprite's size.</returns>
    private Vector3 GetRandomPosition()
    {
        // Whether the planet spawns from a vetical axis
        bool isVertical = Random.value > 0.5f ? true : false;
        float x;
        float y;

        if (isVertical)
        {
            x = CameraController.ScreenBounds.x * -_direction.x;
            y = Random.Range(0f, CameraController.ScreenBounds.y) * -_direction.y;
        }
        else
        {
            x = Random.Range(0f, CameraController.ScreenBounds.x) * -_direction.x;
            y = CameraController.ScreenBounds.y * -_direction.y;
        }
        x += _spriteWidthOffset * -_direction.x;
        y += _spriteHeightOffset * -_direction.y;
        
        return new Vector3(x, y, transform.position.z);
    }

    /// <summary>
    /// Moves the current planet based on the direction vector.
    /// </summary>
    /// <param name="speed">The speed to move at.</param>
    private void Move(float speed)
    {
        transform.position += new Vector3(speed * Time.deltaTime * _direction.x, speed * Time.deltaTime * _direction.y, 0f);
        if (IsOutOfBounds())
        {
            ConfigurePlanet();
        }
    }

    /// <summary>
    /// Checks if the planet is out of bounds.
    /// The planet is out of bounds if its sprite is past the horizontal or verticla screen bounds.
    /// </summary>
    /// <returns>True if out of bounds. False if not out of bounds.</returns>
    private bool IsOutOfBounds()
    {
        return transform.position.x < -CameraController.ScreenBounds.x - _spriteWidthOffset ||
            transform.position.x > CameraController.ScreenBounds.x + _spriteWidthOffset ||
            transform.position.y < -CameraController.ScreenBounds.y - _spriteHeightOffset ||
            transform.position.y > CameraController.ScreenBounds.y + _spriteHeightOffset;
    }
}
