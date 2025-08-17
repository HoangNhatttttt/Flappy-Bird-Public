using UnityEngine;

public class MenuTitleAnimation : MonoBehaviour
{
    public float amplitude = 20f;
    public float frequency = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0f, yOffset, 0f);
    }
}
