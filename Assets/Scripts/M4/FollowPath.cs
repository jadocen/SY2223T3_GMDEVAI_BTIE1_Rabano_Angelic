using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;


    public void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<NavMeshAgent>();
    }
    
    public void GoToHelipad()
    {
        agent.SetDestination(wps[0].transform.position);
    }
    public void GoToRuins()
    {
        agent.SetDestination(wps[6].transform.position);
    }
    public void GoToFactory()
    {
        agent.SetDestination(wps[7].transform.position);
    }
}
