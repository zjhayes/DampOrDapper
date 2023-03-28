using UnityEngine;

public class UmbrellaController : GameBehaviour
{
    [SerializeField]
    UmbrellaPose currentPose;

    public delegate void OnPoseUpdated();
    public event OnPoseUpdated onPoseUpdated;

    public UmbrellaPose CurrentPose
    {
        get { return currentPose; }
        set 
        {
            currentPose = value;
            onPoseUpdated?.Invoke();
        }
    }
}

public enum UmbrellaPose
{
    OPEN,
    CLOSED
}