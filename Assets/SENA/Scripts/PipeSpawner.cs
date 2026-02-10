
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnTime = 1.6f;
    [SerializeField] private float height = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(3f, Random.Range(-height, height), 0);
            Instantiate(pipePrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
