using UnityEngine;

public class GameArea : MonoBehaviour
{
    private const float DefaultAreaWidth = 10f;

    protected float _areaWidth;


    public void Init(Rect cameraRect)
    {
        _areaWidth = GetAreaWidth(cameraRect);
    }


    private float GetAreaWidth(Rect cameraRect)
    {
        float spawnAreaWidth = cameraRect.width / cameraRect.height;
        return spawnAreaWidth * DefaultAreaWidth;
    }
}
