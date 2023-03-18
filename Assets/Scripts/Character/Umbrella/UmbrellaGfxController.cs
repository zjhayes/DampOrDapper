using UnityEngine;

public class UmbrellaGfxController : GameBehaviour
{
    [SerializeField]
    UmbrellaController umbrella;
    [SerializeField]
    GameObject cane;
    [SerializeField]
    GameObject openUmbrella;
    [SerializeField]
    GameObject closedUmbrella;

    void Awake()
    {
        UpdatePose();
    }

    void OnEnable()
    {
        umbrella.onPoseUpdated += UpdatePose;
    }

    void UpdatePose()
    {
        UmbrellaPose pose = umbrella.CurrentPose;

        if(pose == UmbrellaPose.OPEN)
        {
            Open();
        }
        else if(pose == UmbrellaPose.CLOSED)
        {
            Close();
        }
    }

    void Open()
    {
        openUmbrella.SetActive(true);
        closedUmbrella.SetActive(false);
    }

    void Close()
    {
        openUmbrella.SetActive(false);
        closedUmbrella.SetActive(true);
    }

    void OnDisable()
    {
        umbrella.onPoseUpdated -= UpdatePose;
    }

}
