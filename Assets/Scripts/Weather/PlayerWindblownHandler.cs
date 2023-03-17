using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(ParticleTrigger))]
public class PlayerWindblownHandler : GameBehaviour
{
    PlayerController player;
    ParticleTrigger windTrigger;

    void Awake()
    {
        player = GetComponent<PlayerController>();
        windTrigger = GetComponent<ParticleTrigger>();

        windTrigger.onTrigger += BlowPlayer;
    }

    void BlowPlayer()
    {
        if(player.Umbrella.CurrentPose == UmbrellaPose.OPEN)
        {
            Debug.Log("Dewburt is windblow.");
        }
    }
}
