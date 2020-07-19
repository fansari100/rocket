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

        ThrustUp(yAxis);
        ThrustSide(xAxis);
    }

    private void ThrustUp(float amount)
    {
        Vector2 force = (transform.up * amount * 30);
        rb.AddForce(force);
    }

    private void ThrustSide(float amount)
    {
        Vector2 force = (transform.right * amount * 30);
        rb.AddForce(force);
    }


}
