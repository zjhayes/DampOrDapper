using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 6.0f;

    const float GROUND_BUFFER = 0.1f;

    private NavMeshAgent agent;
    private Rigidbody rigidBody;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
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

    public Rigidbody RigidBody
    {
        get { return rigidBody; }
    }

    public bool IsGrounded
    {
        get { return DistanceToGround() <= GROUND_BUFFER; }
    }

    public float DistanceToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            return hit.distance;
        }
        else
        {
            return float.MaxValue;
        }
    }
}
