using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    [SerializeField] private int THRUSTER_FORCE = 100;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem exhaustRight;
    [SerializeField] private ParticleSystem exhaustLeft;
    private Dictionary<float, ParticleSystem> thrusters;
    private int HALF_WIDTH = Screen.width / 2;
    /*
    Vector2 objectPos;
    Vector3 objectDir;
    float torque;
    */
    void Start()
    {
        LoadThrusters();
    }
    void Update()
    {
        /*
        objectPos = new Vector2(transform.position.x, transform.position.y);
        objectDir = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.right;
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        */
        #if UNITY_IOS
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.position.x < HALF_WIDTH)
                    {
                        Thrust(-1f);
                    }
                    else
                    {
                        Thrust(1f);
                    }
                }
            }
        #else
            Thrust(Input.GetAxisRaw("Horizontal") * -1);
        #endif
    }

    private void LoadThrusters()
    {
        thrusters = new Dictionary<float, ParticleSystem>();
        thrusters.Add(-1f, exhaustLeft);
        thrusters.Add(1f, exhaustRight);
    }

    private void Thrust(float direction)
    {
        if (direction != 0f)
        {
            Vector2 force = (transform.up * THRUSTER_FORCE);
            rb.AddForce(force);
            rb.AddTorque(direction * 0.5f);
            thrusters[direction].Emit(1);
        }
    }
}
