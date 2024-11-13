using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerater : MonoBehaviour
{
    [SerializeField] private float ShootingSpeed = 5f;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;  // プレイヤーの位置を取得
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.up = direction;  // つららの向きをプレイヤーに合わせる
        }
    }

    void Update()
    {
        // プレイヤーに向かって移動
        transform.position += transform.up * ShootingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 攻撃オブジェクトに当たったら消滅
        if (other.CompareTag("Projectile") || other.CompareTag("Player"))
        {
            Destroy(other.gameObject);  // 攻撃オブジェクトを消す
            Destroy(gameObject);  // つららオブジェクトを消す
        }
    }
}
