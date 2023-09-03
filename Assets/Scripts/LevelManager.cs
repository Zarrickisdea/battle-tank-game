using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : GenericSingleton<LevelManager>
{
    [SerializeField] private List<GameObject> levelBuildingPieces;
    [SerializeField] private float destroyTime;
    [SerializeField] private GameObject explosionPrefab;

    public void DestroyLevel()
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
    }
}
