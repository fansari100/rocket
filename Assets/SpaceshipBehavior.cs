using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D))
            ThrustRight();
        if (Input.GetKey(KeyCode.A))
            ThrustLeft();
    }

    private void ThrustRight()
    {
        Vector2 force = (transform.up * 100);
        Vector2 m_NewPosition = new Vector2(-0.01f, 0.0f);
        Vector2 objectPosition = new Vector2(transform.position.x, transform.position.y);

        rb.AddForceAtPosition(force, objectPosition + m_NewPosition);
    }

    private void ThrustLeft()
    {
        Vector2 force = (transform.up * 100);
        Vector2 m_NewPosition = new Vector2(0.01f, 0.0f);
        Vector2 objectPosition = new Vector2(transform.position.x, transform.position.y);

        rb.AddForceAtPosition(force, objectPosition + m_NewPosition);
    }


}
