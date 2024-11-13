using UnityEngine;

public class IcicleSpawner : MonoBehaviour
{
    public GameObject iciclePrefab; // つららのプレハブ
    public float spawnRadius = 10f; // 円周の半径
    public float spawnInterval = 2f; // つらら生成間隔

    private Transform player; // プレイヤーの位置

    private void Start()
    {
        InvokeRepeating(nameof(SpawnIcicle), 0f, spawnInterval); // 定期的に生成
    }

    private void SpawnIcicle()
    {
        // 円周上のランダムな位置を計算
        float angle = Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;

        // つららを生成し、プレイヤーに向かせる
        GameObject icicle = Instantiate(iciclePrefab, spawnPosition, Quaternion.identity);
    }
}