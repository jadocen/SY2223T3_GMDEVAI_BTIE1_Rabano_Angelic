using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToGoal : MonoBehaviour
{
    public Transform goal;
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(goal);
        Vector3 direction = goal.position - this.transform.position;

        if (direction.magnitude > 1.5)
        { 
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); 
        }
    }
}
