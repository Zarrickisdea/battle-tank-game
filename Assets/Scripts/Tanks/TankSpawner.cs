using UnityEngine;
using Cinemachine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        TankController tankController = SpawnTank();
        SpawnCamera(tankController);
    }

    private TankController SpawnTank()
    {
        TankModel tankModel = new TankModel(15.0f);
        TankController tankController = new TankController(tankPrefab, tankModel);
        return tankController;
    }

    private void SpawnCamera(TankController tankController)
    {
        GameObject.Instantiate<CinemachineVirtualCamera>(virtualCamera);
        virtualCamera.transform.position = new Vector3(35, 15, 35);
        virtualCamera.Follow = tankController.GetTankView();
    }
}
