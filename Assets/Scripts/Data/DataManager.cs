using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class IslandData
{
    public int islandID;
    public bool lockisland;
    public string islandName;
    public int islandLevel;
    public int price;
    public int getMoneyAmount;
}

public class DataManager : MonoBehaviour
{
    public List<IslandData> islandDatas = new List<IslandData>();
    readonly string islandDataPath = Path.Combine(Application.streamingAssetsPath, "Island.csv");
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        CSVLoader(islandDataPath);
    }

    private void CSVLoader(string path)
    {
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
                    lockisland = bool.Parse(values[1]),
                    islandName = values[2],
                    islandLevel = int.Parse(values[3]),
                    price = int.Parse(values[4]),
                    getMoneyAmount = CalculateMoneyAmount(int.Parse(values[4]), int.Parse(values[3]))
                };

                islandDatas.Add(island);
            }
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }
    }

    private int CalculateMoneyAmount(int price, int level)
    {
        if (price == 0 || level == 0) return 0;
        return price / (price / level);
    }

    private void CSVSave(string path)
    {
        // CSV 파일의 헤더를 작성
        string header = "islandID,lockisland,islandName,islandLevel,price,getMoneyAmount";
        List<string> lines = new List<string> { header };

        // islandDatas 리스트의 각 IslandData를 CSV 형식으로 변환하여 추가
        foreach (var island in islandDatas)
        {
            string line = $"{island.islandID},{island.lockisland},{island.islandName},{island.islandLevel},{island.price},{island.getMoneyAmount}";
            lines.Add(line);
        }

        // 기존의 StreamingAssets/Island.csv 파일에 덮어쓰기
        File.WriteAllLines(path, lines);
        Debug.Log("CSV file saved to " + path);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            int random = Random.Range(0, islandDatas.Count);
            islandDatas[random].islandLevel++;

            CSVSave(islandDataPath);
        }
    }
}
