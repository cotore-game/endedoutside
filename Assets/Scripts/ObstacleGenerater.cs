using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerater : MonoBehaviour
{
    [SerializeField] private float ShootingSpeed = 50f;
    Vector3 direction = Vector3.zero;   

    private void Update()
    {
        // オブジェクトの位置から原点 (0, 0, 0) を引いて方向ベクトルを計算
        direction = Vector3.zero - transform.position;

        // `LookRotation`を使って、初期状態（Rotation 0 0 0）からpi/2方向に調整
        Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0);

        // ターゲット方向に回転
        transform.rotation = targetRotation;
    }
}
