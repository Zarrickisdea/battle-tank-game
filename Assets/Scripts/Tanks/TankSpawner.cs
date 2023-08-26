using UnityEngine;
using Cinemachine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private TankView tankPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        TankController tankController = SpawnTank();
        SetCamera(tankController);
    }

    private TankController SpawnTank()
    {
        TankModel tankModel = new TankModel(speed);
        TankController tankController = new TankController(tankPrefab, tankModel);
        return tankController;
    }

    private void SetCamera(TankController tankController)
    {
        virtualCamera.Follow = tankController.GetTankView();
    }
}
