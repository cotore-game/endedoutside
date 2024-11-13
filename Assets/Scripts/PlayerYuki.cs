using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYuki : MonoBehaviour
{
    public GameObject[] projectilePrefab;  // 発射する攻撃オブジェクトのプレハブ

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 左クリックで発射
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        int i = 0;
        i = Random.Range(0, projectilePrefab.Length);

        // 発射オブジェクトの生成
        GameObject gbobject = Instantiate(projectilePrefab[i], direction, Quaternion.identity);
        gbobject.transform.up = direction;
    }
}
