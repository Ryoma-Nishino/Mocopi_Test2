using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefab; // 出現させるプレハブ
    public GameObject target; // 出現位置の基準となるオブジェクト
    public float interval = 1.0f; // 出現間隔（秒）
    public float radius = 5.0f; // 出現する円の半径
    public float minAngle = -75.0f; // 出現する角度の最小値
    public float maxAngle = 75.0f; // 出現する角度の最大値

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
