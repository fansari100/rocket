using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    public const int MAX_STARS = 25;
    public const float STAR_SIZE = 0.3f;
    public const float STAR_SCALE = 0.3f;
    public const float STAR_SPEED = -0.25f;

    [SerializeField] private ParticleSystem ps;
    private ParticleSystem.Particle[] stars = new ParticleSystem.Particle[MAX_STARS];
    private Color starColor = new Color(1f, 1f, 1f, 1f);
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = GetScreenBounds();
        CreateStars();
        ps.SetParticles(stars, stars.Length);
    }

    // Update is called once per frame
    void Update()
    {
        MoveStars(STAR_SPEED);
    }

    private void CreateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
           stars[i].position = GetRandomPosition();
           stars[i].startSize = GetRandomSize(STAR_SIZE);
           stars[i].startColor = starColor;
        }
    }

    private Vector3 GetScreenBounds()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-screenBounds.x, screenBounds.x);
        float y = Random.Range(-screenBounds.y, screenBounds.y);
        return new Vector3(x, y, -1f);
    }

    private float GetRandomSize(float size)
    {
        return size * Random.Range(STAR_SCALE, 1f - STAR_SCALE);
    }

    private void MoveStars(float speed)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].position = stars[i].position + new Vector3(0f, speed * Time.deltaTime, 0f);
            if (IsOutOfBounds(stars[i].position))
            {
                Vector3 position = GetRandomPosition();
                stars[i].position = new Vector3(position.x, screenBounds.y, position.z);
            }
        }
        ps.SetParticles(stars);
    }

    private bool IsOutOfBounds(Vector3 position)
    {
        return position.y <= -screenBounds.y;
    }
}
