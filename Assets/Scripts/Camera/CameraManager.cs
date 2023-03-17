using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    public Camera ActiveCamera
    {
        get { return mainCamera; }
    }
}