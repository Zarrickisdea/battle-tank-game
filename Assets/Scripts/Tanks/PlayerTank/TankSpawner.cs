using UnityEngine;
using Cinemachine;
using ScriptableObjects.Tanks;
using PlayerTank;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankListScriptableObject tankList;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        TankController playerTankController = SpawnTank();
        SetCamera(playerTankController);
    }

    private TankController SpawnTank()
    {
        TankScriptableObject newTank = GetRandomTank();
        TankModel tankModel = new TankModel(newTank);
        TankController tankController = new TankController(newTank.TankView, tankModel);
        return tankController;
    }

    private void SetCamera(TankController tankController)
    {
        virtualCamera.Follow = tankController.GetTankViewTransform();
    }

    private TankScriptableObject GetRandomTank()
    {
        return tankList[Random.Range(0, tankList.Count)];
    }
}
