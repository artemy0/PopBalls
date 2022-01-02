using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    private const float DefaultSpawnAreaWidth = 10f;

    [SerializeField] private Transform _spawnAnchor;

    private float _spawnAreaWidth;


    public void Init(Rect cameraRect)
    {
        _spawnAreaWidth = GetSpawnAreaWidth(cameraRect);
    }

    public Vector3 GetSpawnPosition()
    {
        Vector3 spawnOffset = Random.Range(-_spawnAreaWidth / 2, _spawnAreaWidth / 2) * Vector3.right;
        Vector3 spawnPosition = _spawnAnchor.position + spawnOffset;

        return spawnPosition;
    }


    private float GetSpawnAreaWidth(Rect cameraRect)
    {
        float spawnAreaWidth = cameraRect.width / cameraRect.height;
        return spawnAreaWidth * DefaultSpawnAreaWidth;
    }
}
