using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject obstacle;
    GameObject[] agents;

    private void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(obstacle, hit.point, obstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControlM6>().DetectNewObstacle(hit.point);
                }
            }
        }
    }
}
