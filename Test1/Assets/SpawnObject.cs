using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefab; // �o��������v���n�u
    public GameObject target; // �o���ʒu�̊�ƂȂ�I�u�W�F�N�g
    public float interval = 1.0f; // �o���Ԋu�i�b�j
    public float radius = 5.0f; // �o������~�̔��a
    public float minAngle = -75.0f; // �o������p�x�̍ŏ��l
    public float maxAngle = 75.0f; // �o������p�x�̍ő�l

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    Vector3 GetSpawnPosition()
    {
        float angle = Random.Range(minAngle, maxAngle) * Mathf.Deg2Rad;
        float x = radius * Mathf.Cos(angle);
        float z = radius * Mathf.Sin(angle);
        Vector3 spawnPosition = new Vector3(x, 0, z);
        spawnPosition = spawnPosition + target.transform.position;
        return spawnPosition;
    }
}
