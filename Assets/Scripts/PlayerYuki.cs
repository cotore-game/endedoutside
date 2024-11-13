using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYuki : MonoBehaviour
{
    public GameObject projectilePrefab;  // ���˂���U���I�u�W�F�N�g�̃v���n�u
    public Transform shootPoint;  // ���ˈʒu

    void Update()
    {
        AimAtMouse();  // �}�E�X�̕���������
        if (Input.GetMouseButtonDown(0))  // ���N���b�N�Ŕ���
        {
            Shoot();
        }
    }

    private void AimAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // �v���C���[�̌������}�E�X�����ɍ��킹��
        transform.up = direction;
    }

    private void Shoot()
    {
        // ���˃I�u�W�F�N�g�̐���
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.transform.up = transform.up;  // �v���C���[�̌����ɍ��킹�Ĕ��˕�����ݒ�
        //projectile.tag = "Projectile";  // �^�O��ݒ�
    }
}
