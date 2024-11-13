using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isicle : MonoBehaviour
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
        Debug.Log("�����Abullet");
        // �U���I�u�W�F�N�g�ɓ������������
        if (other.CompareTag("randoseru") || other.CompareTag("Player"))
        {
            Destroy(gameObject);  // ���I�u�W�F�N�g������
        }
    }
}
