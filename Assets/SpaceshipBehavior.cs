using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem exhaustRight;
    public ParticleSystem exhaustLeft;

    Vector2 objectPos;
    Vector3 objectDir;
    float torque;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // exhaustRight = GetComponent<ParticleSystem>();
        // exhaustLeft = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        objectPos = new Vector2(transform.position.x, transform.position.y);
        objectDir = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.right;

        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        Vector2 force = (transform.up * 100);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(force);
            ThrustRight();
            exhaustLeft.Emit(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(force);
            ThrustLeft();
            exhaustRight.Emit(1);
        }
    }

    private void ThrustRight()
    {
        rb.AddTorque(-1);
    }

    private void ThrustLeft()
    {
        rb.AddTorque(1);
    }
}
