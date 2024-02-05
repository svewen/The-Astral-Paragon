using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; // Player's transform
    public float chaseRange = 10f; // Distance at which the enemy starts chasing

    public float health = 3;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Chase();
    }

    private void Chase()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check if the player is within the chase range
        if (distanceToTarget <= chaseRange && distanceToTarget >= 2f)
        {
            // Set the destination for the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            // Stop chasing if the player is outside the chase range
            navMeshAgent.ResetPath();
        }
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Hit: " + health + " hp");

        if (health <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
