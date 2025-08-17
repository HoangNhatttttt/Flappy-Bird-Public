using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float minSpawnRate = 1.25f;
    public float maxSpawnRate = 1.5f;

    private Coroutine spawningSparkCoroutine;

    IEnumerator SpawningPipesRandom()
    {
        while (true)
        {
            SpawingSpark();
            float waitTime = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void StartSpawningSpark()
    {
        if (spawningSparkCoroutine == null)
            spawningSparkCoroutine = StartCoroutine(SpawningPipesRandom());
    }

    public void StopSpawningSpark()
    {
        if (spawningSparkCoroutine != null)
        {
            StopCoroutine(spawningSparkCoroutine);
            spawningSparkCoroutine = null;
        }
    }

    private void SpawingSpark()
    {
        // GameObject, Position, Rotation ; Quaternion.identity nghĩa là Rotation = 0
        GameObject spark = Instantiate(prefab, transform);

        RectTransform sparkCanvas = spark.transform.parent.GetComponent<RectTransform>();
        
        float sparkSpawnX = Random.Range(-sparkCanvas.rect.width/2, sparkCanvas.rect.width/2);
        float sparkSpawnY = Random.Range(-sparkCanvas.rect.height/2, sparkCanvas.rect.height/2);

        spark.GetComponent<RectTransform>().anchoredPosition = new Vector3(sparkSpawnX, sparkSpawnY, 0);
    }

    public void DestroySpark()
    {
        Spark[] sparks = FindObjectsOfType<Spark>();

        for (int i = 0; i < sparks.Length; i++)
            Destroy(sparks[i].gameObject);
    }
}
