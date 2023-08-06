using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum State
//{
//    Idle,
//    Running,
//    Casting
//}

public class AIControlM7 : MonoBehaviour
{
    public Transform player;

    float rotationSpeed = 2.0f;
    float speed = 2.0f;
    float visionDist = 20.0f;
    float visionAngle = 30.0f;
    float castRange = 5.0f;

    State state;

    private void LateUpdate()
    {
        Vector3 dir = player.position - this.transform.position;
        float angle = Vector3.Angle(dir, this.transform.position);

        if (dir.magnitude < visionDist && angle < visionAngle)
        {
            dir.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                 Quaternion.LookRotation(dir),
                                                 Time.deltaTime * rotationSpeed);

            if (dir.magnitude > castRange)
            {
                state = State.Running;
            }
            else
            {
                state = State.Idle;
            }

            if (state == State.Running)
            {
                this.transform.Translate(0, 0, Time.deltaTime * speed);
            }
        }
    }
}