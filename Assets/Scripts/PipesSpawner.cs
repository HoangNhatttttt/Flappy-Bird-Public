using UnityEngine;
using System.Collections;

public class PipesSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float minSpawnRate = 1.25f;
    public float maxSpawnRate = 1.5f;

    public float minPipesHeight = -2f;
    public float maxPipesHeight = 2f;

    public float minTopPipe = 0f;
    public float maxTopPipe = 0.25f;

    public float minBottomPipe = -0.25f;
    public float maxBottomPipe = 0f;

    private float topRandom;
    private float bottomRandom; 

    private Coroutine spawningPipesCoroutine;

    IEnumerator SpawningPipesRandom()
    {
        while (true)
        {
            SpawnPipes();
            float waitTime = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(waitTime); 
        }
    }

    public void StartSpawningPipes()
    {
        if (spawningPipesCoroutine == null)
            spawningPipesCoroutine = StartCoroutine(SpawningPipesRandom());
    }

    public void StopSpawningPipes()
    {
        if (spawningPipesCoroutine != null)
        {
            StopCoroutine(spawningPipesCoroutine);
            spawningPipesCoroutine = null;
        }
    }

    private void SpawnPipes()
    {
        // GameObject, Position, Rotation ; Quaternion.identity nghĩa là Rotation = 0
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        pipes.transform.position += Vector3.up * Random.Range(minPipesHeight, maxPipesHeight);

        GameObject topPipe = pipes.transform.GetChild(0).gameObject;
        GameObject bottomPipe = pipes.transform.GetChild(2).gameObject;

        topRandom = Random.Range(minTopPipe, maxTopPipe);
        bottomRandom = Random.Range(minBottomPipe, maxBottomPipe);

        topPipe.transform.position += Vector3.up * topRandom;
        bottomPipe.transform.position += Vector3.up * bottomRandom;
    }

    public void DestroyPipes()
    {
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
            Destroy(pipes[i].gameObject);
    }

    public void StopPipesMoving()
    {
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
            pipes[i].enableMoving = 0;
    }

    public float getTopRandom()
    {
        return topRandom;
    }

    public float getBottomRandom()
    {
        return bottomRandom;
    }
}
