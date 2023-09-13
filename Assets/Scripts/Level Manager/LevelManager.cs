using EnemyTank;
using PlayerTank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : GenericSingleton<LevelManager>
{
    [SerializeField] private List<GameObject> levelBuildingPieces;
    [SerializeField] private float destroyTime;
    [SerializeField] private GameObject explosionPrefab;

    private List<EnemyTankView> enemyTanks = new List<EnemyTankView>();

    public TankView PlayerTank { get; set; }

    private void DestroyLevel()
    {
        StartCoroutine(DestroyLevelPieces());
    }

    private IEnumerator DestroyLevelPieces()
    {
        foreach (GameObject levelPiece in levelBuildingPieces)
        {
            yield return new WaitForSeconds(destroyTime);

            levelPiece.SetActive(false);

            GameObject explosion = Instantiate(explosionPrefab, levelPiece.transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(explosion, 1f);

            yield return new WaitForSeconds(destroyTime);
        }

        yield return new WaitForSeconds(destroyTime);
        SceneManager.LoadScene("GameOver");
    }

    public void AddEnemyTank(EnemyTankView enemyTankView)
    {
        enemyTanks.Add(enemyTankView);
    }

    public void RemoveEnemyTank(EnemyTankView enemyTankView)
    {
        enemyTanks.Remove(enemyTankView);
        if (enemyTanks.Count == 0)
        {
            DestroyLevel();
        }
    }

    public void RemovePlayerTank()
    {
        PlayerTank = null;
        DestroyLevel();
    }
}
