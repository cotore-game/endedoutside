using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYuki : MonoBehaviour
{
    public GameObject[] projectilePrefab;  // ���˂���U���I�u�W�F�N�g�̃v���n�u

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ���N���b�N�Ŕ���
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

        // ���˃I�u�W�F�N�g�̐���
        GameObject gbobject = Instantiate(projectilePrefab[i], direction, Quaternion.identity);
        gbobject.transform.up = direction;
    }
}
