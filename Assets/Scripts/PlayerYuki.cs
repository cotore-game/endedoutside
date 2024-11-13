using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYuki : MonoBehaviour
{
    public GameObject projectilePrefab;  // 発射する攻撃オブジェクトのプレハブ
    public Transform shootPoint;  // 発射位置

    void Update()
    {
        AimAtMouse();  // マウスの方向を向く
        if (Input.GetMouseButtonDown(0))  // 左クリックで発射
        {
            Shoot();
        }
    }

    private void AimAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // プレイヤーの向きをマウス方向に合わせる
        transform.up = direction;
    }

    private void Shoot()
    {
        // 発射オブジェクトの生成
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.transform.up = transform.up;  // プレイヤーの向きに合わせて発射方向を設定
        //projectile.tag = "Projectile";  // タグを設定
    }
}
