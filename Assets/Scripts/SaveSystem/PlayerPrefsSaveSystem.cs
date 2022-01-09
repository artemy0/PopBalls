using UnityEngine;

/*
�����:
1. ����� ������������
2. ������������������ API (Android, iOS, Windows, ...)
������: 
1. ������ ����������������
2. ��� ��������� ������� �����
3. ������������� ����������� ������ ����� �����������
*/
public class PlayerPrefsSaveSystem : ISaveSystem
{
    private const string BEST_SCORE_KEY = "best_score";

    public void Save(SaveData data)
    {
        PlayerPrefs.SetInt(BEST_SCORE_KEY, data.BestScore);

        PlayerPrefs.Save();
    }

    public SaveData Load()
    {
        SaveData data = new SaveData();

        data.BestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);

        return data;
    }
}
