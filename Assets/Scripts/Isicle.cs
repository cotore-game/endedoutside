using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isicle : MonoBehaviour
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
        Debug.Log("うっ、bullet");
        // 攻撃オブジェクトに当たったら消滅
        if (other.CompareTag("randoseru") || other.CompareTag("Player"))
        {
            Destroy(gameObject);  // つららオブジェクトを消す
        }
    }
}
