﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum DataType
{
    Island,
    Pet,
}

[System.Serializable]
public class IslandData
{
    public int islandID;
    public bool unlockisland;
    public string islandName;
    public int islandLevel;
    public int price;
    public int moneyDrop;
    public int heartDrop;
}

public class DataManager : MonoBehaviour
{
    public List<IslandData> islandDatas = new List<IslandData>();
    readonly string islandDataPath = Path.Combine(Application.streamingAssetsPath, "Island.csv");
    //readonly string petDataPath = Path.Combine(Application.streamingAssetsPath, "Pet.csv");
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        CSVLoader(DataType.Island);
        // CSVLoader(DataType.Pet);
    }

    private void CSVLoader(DataType type)
    {
        if (type == DataType.Island)
        {
            string path = islandDataPath;

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] values = line.Split(',');

                    IslandData island = new IslandData
                    {
                        islandID = int.Parse(values[0]),
                        unlockisland = bool.Parse(values[1]),
                        islandName = values[2],
                        islandLevel = int.Parse(values[3]),
                        price = int.Parse(values[4]),
                        moneyDrop = CalculateAmount(int.Parse(values[4]), int.Parse(values[3])),
                        heartDrop = int.Parse(values[0]) + int.Parse(values[3]),
                    };

                    islandDatas.Add(island);
                }
            }
            else
            {
                Debug.LogError("File not found: " + path);
            }
        }
        else if (type == DataType.Pet)
        {
            //string path = petDataPath;
        }
    }

    private int CalculateAmount(int price, int level)
    {
        if (price == 0 || level == 0) return 0;
        return price / (price / level);
    }

    public void CSVSave(DataType type)
    {
        if(type == DataType.Island)
        {
            string path = islandDataPath;
            // CSV 파일의 헤더를 작성
            string header = "islandID,unlockisland,islandName,islandLevel,price,MoneyDrop,HeartDrop";
            List<string> lines = new List<string> { header };

            // islandDatas 리스트의 각 IslandData를 CSV 형식으로 변환하여 추가
            foreach (var island in islandDatas)
            {
                string line = $"{island.islandID},{island.unlockisland},{island.islandName},{island.islandLevel},{island.price},{island.moneyDrop}";
                lines.Add(line);
            }

            // 기존의 StreamingAssets/Island.csv 파일에 덮어쓰기
            File.WriteAllLines(path, lines);
            Debug.Log("CSV file saved to " + path);
        }
        else if(type == DataType.Pet)
        {
            // TODO
        }
    }

}
