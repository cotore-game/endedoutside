using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ish : MonoBehaviour
{
    [SerializeField] private float ShootingSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * ShootingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("���Abulletish");
        // �U���I�u�W�F�N�g�ɓ������������
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);  // ���I�u�W�F�N�g������
        }
    }
}
