using UnityEngine;

/* Add to ParticleTriggerDetection component */
[RequireComponent(typeof(Collider))]
public class ParticleTrigger : MonoBehaviour
{
    [SerializeField]
    ParticleTriggerDetector detector;

    public delegate void OnTrigger();
    public event OnTrigger onTrigger;

    void Start()
    {
        detector.AddTrigger(this);
    }

    public virtual void Trigger()
    {
        onTrigger?.Invoke();
    }
}
