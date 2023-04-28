using UnityEngine;
using UnityEngine.VFX;

public class WhirlwindController : GameBehaviour
{
    [SerializeField]
    float launchSpeed = 15.0f;
    [SerializeField]
    float dissolveSpeed = 1.0f;
    [SerializeField]
    GameObject whirlwindPrefab;
    [SerializeField]
    string dissolveParameterName = "Dissolve";

    PlayerController player;

    Vector3 initialPosition;

    bool isReleased;
    bool isLaunched;
    GameObject currentWhirlwind;
    /*
    void Start()
    {
        player = gameManager.Player;
        isReleased = false;
        isLaunched = false;
    }

    void Update() // TODO: Replace Update method
    {
        if(player.Movement.IsGrounded)
        {
            if(currentWhirlwind != null)
            {
                DissolveWhirlwind();
            }
        }
        else if (currentWhirlwind != null & (isLaunched || (!isLaunched && isReleased )))
        {
            DissolveWhirlwind();
        }

    }

    public void Boost()
    {
        if(player.Movement.IsGrounded && currentWhirlwind == null)
        {
            // Create whirlwind and hover character.
            initialPosition = player.transform.position;
            currentWhirlwind = (GameObject) Instantiate(whirlwindPrefab, initialPosition, Quaternion.identity);
            player.Context.Hover();
        }
        else
        {
            // Launch character on second trigger.
            if(!isLaunched)
            {
                Launch();
            }
        }
    }

    void Launch()
    {
        Vector3 launchVelocity = new Vector3(0f, launchSpeed, 0f);
        player.Movement.RigidBody.velocity = player.Movement.RigidBody.velocity + launchVelocity;
        isLaunched = true;
    }

    void DissolveWhirlwind()
    {
        VisualEffect whirlwindEffect = currentWhirlwind.GetComponent<VisualEffect>();
        float dissolve = whirlwindEffect.GetFloat(dissolveParameterName);
        if (dissolve <= 1f)
        {
            whirlwindEffect.SetFloat(dissolveParameterName, dissolve + (dissolveSpeed * Time.deltaTime));
        }
        else
        {
            Destroy(currentWhirlwind);
            currentWhirlwind = null;
            isLaunched = false;
            isReleased = false;
        }
    }

    public void Release()
    {
        isReleased = true;
        if(!isLaunched)
        {
            player.Context.Continue();
        }
    }*/
}
