using UnityEngine;
using UnityEngine.AI;

public class AIControlM6 : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator animator;

    float speedMultiplier;
    float detectionRadius = 5f;
    float fleeRadius = 10;
    float targetRadius = 10;

    public void DetectNewTarget(Vector3 location)   //Location = Right click Vec3
    {
        //if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        Vector3 targetDirection = (this.transform.position - location).normalized;
        Vector3 newGoal = this.transform.position - targetDirection * targetRadius; //this - target = towards

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(newGoal, path);

        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            agent.SetDestination(path.corners[path.corners.Length - 1]);
            animator.SetTrigger("isRunning");
            agent.speed = 10;
            agent.angularSpeed = 200;
        }
    }

    public void DetectNewObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius; //this + target = away

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }

    public void ResetAgent()
    {
        speedMultiplier = Random.Range(0.1f, 1.5f);
        agent.speed = 2 * speedMultiplier;
        agent.angularSpeed = 120;
        animator.SetFloat("speedMultiplier", speedMultiplier);
        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }

    private void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        animator.SetTrigger("isWalking");
        animator.SetFloat("wOffset", Random.Range(0.1f, 1f));

        speedMultiplier = Random.Range(0.1f, 1f);
        agent.speed = 2 * speedMultiplier;
        animator.SetFloat("speedMultiplier", speedMultiplier);
    }

    private void Update()
    {
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}