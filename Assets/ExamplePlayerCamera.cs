using Cinemachine;
using UnityEngine;

public class ExamplePlayerCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject MainCamera;
    [SerializeField]
    private CinemachineVirtualCamera CameraForward;
    [SerializeField]
    private CinemachineVirtualCamera CameraBackwards;

    private Vector3 _playerForward;
    private int _orientation; //-1 backwards, 0 unknown, 1 forward

    private void Start()
    {
        _orientation = 0;
    }

    private void Update()
    {
        //Update the current player forward (where the player is looking)
        _playerForward = transform.forward;
        _playerForward.Set(_playerForward.x, 0f, _playerForward.z);

        if (_orientation != 1 && IsLookingForward())
        {
            _orientation = 1;
            CameraForward.Priority = 2;
            CameraBackwards.Priority = 1;
        }
        else if (_orientation != -1 && IsLookingBackwards())
        {
            _orientation = -1;
            CameraForward.Priority = 1;
            CameraBackwards.Priority = 2;
        }
    }

    private bool IsLookingForward()
    {
        return (Vector3.Dot(_playerForward, MainCamera.transform.forward) > 0.1f);
    }

    private bool IsLookingBackwards()
    {
        return (Vector3.Dot(_playerForward, MainCamera.transform.forward) <= -0.1f);
    }

}