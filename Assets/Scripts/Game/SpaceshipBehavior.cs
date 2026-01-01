using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    [SerializeField] private int THRUSTER_FORCE = 80;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem exhaustRight;
    [SerializeField] private ParticleSystem exhaustLeft;
    private Dictionary<float, ParticleSystem> rockets;
    private int HALF_WIDTH = Screen.width / 2;
    /*
    Vector2 objectPos;
    Vector3 objectDir;
    float torque;
    */
    void Start()
    {
        LoadRockets();
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
            if (Input.GetKey(KeyCode.D))
            {
                Thrust(-1f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Thrust(1f);
            }
        #endif
    }

    private void LoadRockets()
    {
        rockets = new Dictionary<float, ParticleSystem>();
        rockets.Add(-1f, exhaustLeft);
        rockets.Add(1f, exhaustRight);
    }

    private void Thrust(float direction)
    {
        if (direction != 0f)
        {
            Vector2 force = (transform.up * THRUSTER_FORCE);
            rb.AddForce(force);
            rb.AddTorque(direction * 0.5f);
            rockets[direction].Emit(1);
        }
    }
}
