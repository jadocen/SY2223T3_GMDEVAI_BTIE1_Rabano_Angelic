using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMCautious : MonoBehaviour
{
    public Transform goal;
    public float speed = 0;
    public float rotSpeed = 20;
    public float acceleration = 2;
    public float deceleration = 5;
    public float turnSpeed = 1.5f;
    public float minSpeed = 0;
    public float maxSpeed = 5;
    public float breakAngle = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, goal.position.y, goal.position.z);
        Vector3 direction = lookAtGoal - transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed);

        //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);

        if (Vector3.Angle(goal.forward, this.transform.forward) > breakAngle && speed > turnSpeed)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else 
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        this.transform.Translate(0, 0, speed);
    }
}
