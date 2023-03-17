using UnityEngine;

public class UmbrellaGfxController : GameBehaviour
{
    [SerializeField]
    GameObject cane;
    [SerializeField]
    GameObject openUmbrella;
    [SerializeField]
    GameObject closedUmbrella;

    UmbrellaController umbrella;

    void Awake()
    {
        umbrella = gameManager.Player.Umbrella;
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
