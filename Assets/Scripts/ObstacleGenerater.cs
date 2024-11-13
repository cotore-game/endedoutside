using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerater : MonoBehaviour
{
    [SerializeField] private float ShootingSpeed = 5f;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;  // �v���C���[�̈ʒu���擾
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.up = direction;  // ���̌������v���C���[�ɍ��킹��
        }
    }

    void Update()
    {
        // �v���C���[�Ɍ������Ĉړ�
        transform.position += transform.up * ShootingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �U���I�u�W�F�N�g�ɓ������������
        if (other.CompareTag("Projectile") || other.CompareTag("Player"))
        {
            Destroy(other.gameObject);  // �U���I�u�W�F�N�g������
            Destroy(gameObject);  // ���I�u�W�F�N�g������
        }
    }
}
