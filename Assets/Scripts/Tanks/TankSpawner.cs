using UnityEngine;
using Cinemachine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        SpawnTank();
    }

    private TankController SpawnTank()
    {
        TankModel tankModel = new TankModel(15.0f);
        TankController tankController = new TankController(tankPrefab, tankModel, virtualCamera);
        return tankController;
    }
}
