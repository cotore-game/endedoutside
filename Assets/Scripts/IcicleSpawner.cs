using UnityEngine;

public class IcicleSpawner : MonoBehaviour
{
    public GameObject iciclePrefab; // ���̃v���n�u
    public float spawnRadius = 10f; // �~���̔��a
    public float spawnInterval = 2f; // ��琶���Ԋu

    private Transform player; // �v���C���[�̈ʒu

    private void Start()
    {
        InvokeRepeating(nameof(SpawnIcicle), 0f, spawnInterval); // ����I�ɐ���
    }

    private void SpawnIcicle()
    {
        // �~����̃����_���Ȉʒu���v�Z
        float angle = Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;

        // ���𐶐����A�v���C���[�Ɍ�������
        GameObject icicle = Instantiate(iciclePrefab, spawnPosition, Quaternion.identity);
    }
}