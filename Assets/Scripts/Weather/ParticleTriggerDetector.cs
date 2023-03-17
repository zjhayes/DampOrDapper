using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleTriggerDetector : MonoBehaviour
{    
    ParticleSystem ps;
    List<ParticleTrigger> triggers;
    List<ParticleSystem.Particle> enter;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        triggers = new List<ParticleTrigger>();
        enter = new List<ParticleSystem.Particle>();
        
    }

    void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        if(numEnter > 0)
        {
            InvokeTriggers();
        }
    }

    void InvokeTriggers()
    {
        foreach(ParticleTrigger trigger in triggers)
        {
            trigger.Trigger();
        }
    }

    public void AddTrigger(ParticleTrigger trigger)
    {
        try
        {
            ps.trigger.SetCollider(triggers.IndexOf(trigger), trigger.gameObject.GetComponent<Collider>());
            triggers.Add(trigger);
        }
        catch(Exception ex)
        {
            Debug.LogException(ex, this);
        }
    }
}
