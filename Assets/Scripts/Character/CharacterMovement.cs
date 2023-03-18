using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 6.0f;

    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void OnEnable()
    {
        agent.enabled = true;
    }

    void OnDisable()
    {
        agent.enabled = false;
    }

    public float Magnitude
    {
        get { return agent.velocity.magnitude; }
    }

    public float Speed
    {
        get { return agent.speed; }
    }

    public float MaxSpeed
    {
        get { return maxSpeed; }
    }

    public NavMeshAgent Agent
    {
        get { return agent; }
    }
}
