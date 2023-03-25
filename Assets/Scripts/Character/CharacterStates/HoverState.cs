using UnityEngine;

/** Character bobs up and down in the air. **/
public class HoverState : CharacterState
{
    [SerializeField]
    float moveSpeed = 2.0f; // Speed at which the rigidbody moves up and down.
    [SerializeField]
    float maxDistance = 2f; // Maximum distance the rigidbody can travel from its initial position.
    [SerializeField]
    float minDistance = 1f; // Minimum distance the rigidbody can travel from its initial position.

    Vector3 initialPosition; // Position where character started to float.
    float initialTime; // Time when character started to float.


    void OnEnable()
    {
        initialTime = Time.time;
        initialPosition = character.transform.position;
        character.Animator.IsHovering(true);
    }

    void FixedUpdate()
    {
        Hover();
    }

    void Hover()
    {
        // Calculate the sine wave value based on the current time and move speed, with the start time offset to ensure movement starts from bottom.
        float sineValue = Mathf.Sin((Time.time - initialTime) * moveSpeed);

        // Map the sine wave value to the range of the minDistance and maxDistance.
        float yOffset = Mathf.Lerp(minDistance, maxDistance, (sineValue + 1f) / 2f);

        // Calculate the new y position of the rigidbody.
        float height = initialPosition.y + yOffset;

        // Set the new position of the rigidbody.
        character.transform.position = new Vector3(initialPosition.x, height, initialPosition.z);
    }

    void OnDisable()
    {
        character.Animator.IsHovering(false);
    }
}
