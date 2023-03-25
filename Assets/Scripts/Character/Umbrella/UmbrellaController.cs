using UnityEngine;

public class UmbrellaController : GameBehaviour
{
    [SerializeField]
    UmbrellaPose currentPose;

    public delegate void PoseUpdated();
    public event PoseUpdated onPoseUpdated;

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