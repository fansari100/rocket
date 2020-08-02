using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    [SerializeField] private int THRUSTER_FORCE = 100;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem exhaustRight;
    [SerializeField] private ParticleSystem exhaustLeft;
    private Dictionary<float, ParticleSystem> thrusters;
    /*
    Vector2 objectPos;
    Vector3 objectDir;
    float torque;
    */
    void Start()
    {
        thrusters = new Dictionary<float, ParticleSystem>();
        thrusters.Add(-1f, exhaustLeft);
        thrusters.Add(1f, exhaustRight);
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
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    Thrust(-1f);
                }
                else
                {
                    Thrust(1f);
                }
            }
        #else
            Thrust(Input.GetAxisRaw("Horizontal") * -1);
        #endif
    }

    private void Thrust(float direction)
    {
        if (direction != 0f)
        {
            Vector2 force = (transform.up * THRUSTER_FORCE);
            rb.AddForce(force);
            rb.AddTorque(direction);
            thrusters[direction].Emit(1);
        }
    }
}
