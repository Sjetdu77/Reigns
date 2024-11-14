using System;
using System.IO;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already an instance of LoadAndSaveData.");
            return;
        }

        instance = this;
    }

    public void SaveData()
    {
        DataSaved Datas = new()
        {
            Health = PlayerMentalHealth.instance.currentMentalHealth,
            Position = PlayerMovement.instance.rigidbodyPlayer.position,
            Region = CurrentSceneManager.instance.activeScene
        };
        File.WriteAllText($"{Application.persistentDataPath}/PlayerDatas.json", JsonUtility.ToJson(Datas));
    }

    public void LoadData()
    {
        string FilePath = $"{Application.persistentDataPath}/PlayerDatas.json";
        var Datas = JsonUtility.FromJson<DataSaved>(File.ReadAllText(FilePath));
        PlayerMovement.instance.rigidbodyPlayer.position = Datas.Position;
        PlayerMentalHealth.instance.currentMentalHealth = Datas.Health;
        CurrentSceneManager.instance.activeScene = Datas.Region;
    }
}

[Serializable]
public class DataSaved
{
    public string Region = "Aramania";
    public Vector2 Position = Vector2.zero;
    public int Level = 1;
    public int Health = 1000;
}
