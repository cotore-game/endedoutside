using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerater : MonoBehaviour
{
    [SerializeField] private float ShootingSpeed = 50f;
    Vector3 direction = Vector3.zero;   

    private void Update()
    {
        // �I�u�W�F�N�g�̈ʒu���猴�_ (0, 0, 0) �������ĕ����x�N�g�����v�Z
        direction = Vector3.zero - transform.position;

        // `LookRotation`���g���āA������ԁiRotation 0 0 0�j����pi/2�����ɒ���
        Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0);

        // �^�[�Q�b�g�����ɉ�]
        transform.rotation = targetRotation;
    }
}
