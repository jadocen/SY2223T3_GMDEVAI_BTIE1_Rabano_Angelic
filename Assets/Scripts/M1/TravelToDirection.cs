using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToDirection : MonoBehaviour
{
    public Vector3 direction = new Vector3(8, 0, -4);
    float movementSpeed = 5;

    Vector3 moveDirection = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
        transform.Translate(moveDirection);
    }

    void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.D)) //RIGHT
        {
            transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
        }

        else if (Input.GetKey(KeyCode.A)) //LEFT
        {
            transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        }

        else if (Input.GetKey(KeyCode.W)) //UP
        {
            transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
        }

        else if (Input.GetKey(KeyCode.S)) //DOWN
        {
            transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime));
        }
    }
}
