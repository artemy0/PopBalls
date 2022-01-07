using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : GameArea
{
    [SerializeField] private Transform _spawnAnchor;


    public void Init(Rect cameraRect)
    {
        base.Init(cameraRect);
    }

    public Vector3 GetSpawnPosition()
    {
        Vector3 spawnOffset = Random.Range(-_areaWidth / 2, _areaWidth / 2) * Vector3.right;
        Vector3 spawnPosition = _spawnAnchor.position + spawnOffset;

        return spawnPosition;
    }
}
