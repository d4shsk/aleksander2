using System.Collections;
using UnityEngine;
using System;

public class EmotGenerator : MonoBehaviour
{
    [SerializeField] private GameObject emotican;
    [SerializeField] private float respawnTime;

    private void Start()
    {
        StartCoroutine(GenerateEmoticans());
    }

    private void SpawnEmotican() {
        GameObject snow = Instantiate(emotican);

        Vector2 cameraPos = Camera.main.transform.position;

        float x = GeneratePosition((int)cameraPos.x - 10, (int)cameraPos.x + 10);
        float y = 6.5f;
        snow.transform.position = new Vector2(x,y);
    }

    private float GeneratePosition(int minPos, int maxPos) {
        int pos = UnityEngine.Random.Range(minPos, maxPos);
        return pos;
    }

    private IEnumerator GenerateEmoticans()
    {
        while (true) {
            SpawnEmotican();
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
