using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    private const float _updateInterval = 3f; 
    private NavMeshAgent agent; 
    private float timeSinceLastUpdate;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timeSinceLastUpdate = _updateInterval;
        agent.enabled = true;
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= _updateInterval)
        {
            Vector3 randomPosition = GetRandomPositionOnNavMesh();
            agent.SetDestination(randomPosition);
            timeSinceLastUpdate = 0f;
        }
    }
    Vector3 GetRandomPositionOnNavMesh()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 2f; 
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 20f, NavMesh.AllAreas))
        {
            return hit.position; 
        }
        else
        {
            return transform.position;
        }
    }
}
