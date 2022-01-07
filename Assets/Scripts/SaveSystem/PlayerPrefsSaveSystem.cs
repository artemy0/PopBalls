using UnityEngine;

/*
ПЛЮСЫ:
1. Легко использовать
2. Кроссплатформенный API (Android, iOS, Windows, ...)
МИНУСЫ: 
1. Плохая масштабируемость
2. Нет поддержки сложных типов
3. Невозможность портировать данные между платформами
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
