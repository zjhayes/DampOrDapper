using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MoistureDetection : MonoBehaviour
{
    int dryness = 100;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(--dryness);
    }
}
