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

    CharacterController character;

    Vector3 initialPosition;

    bool isReleased;
    bool isLaunched;
    GameObject currentWhirlwind;

    void Start()
    {
        character = gameManager.Character;
        isReleased = false;
        isLaunched = false;
    }

    void Update() // TODO: Replace Update method
    {
        if(character.Movement.IsGrounded)
        {
            isLaunched = false;
            isReleased = false;
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
        if(character.Movement.IsGrounded && currentWhirlwind == null)
        {
            initialPosition = character.transform.position;
            currentWhirlwind = (GameObject) Instantiate(whirlwindPrefab, initialPosition, Quaternion.identity);
            character.Context.Hover();
        }
        else
        {
            // Launch character.
            if(!isLaunched)
            {
                Vector3 launchVelocity = new Vector3(0f, launchSpeed, 0f);
                character.Movement.RigidBody.velocity = character.Movement.RigidBody.velocity + launchVelocity;
                isLaunched = true;
            }
        }
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
        }
    }

    public void Release()
    {
        isReleased = true;
        if(!isLaunched)
        {
            character.Context.Continue();
        }
    }
}
