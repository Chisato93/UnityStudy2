using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum DataType
{
    Island,
    Animal,
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

[System.Serializable]
public class AnimalData
{
    public int animalID;
    public string animalName;
    public bool unlockAnimal;
    public string imagePath;
    public int animalLevel;
    public int animalCount;
    public int animalEffect;
    public int price;
}

public class DataManager : MonoBehaviour
{

    #region Singlton
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);


        Init();
    }
    #endregion
    public List<IslandData> islandDatas = new List<IslandData>();
    public List<AnimalData> animalDatas = new List<AnimalData>();

    public IslandData nextIsland { get; set; } = null;
    public IslandData currentIsland { get; set; } = null;

    readonly string islandDataPath = Path.Combine(Application.streamingAssetsPath, "Island.csv");
    readonly string animalDataPath = Path.Combine(Application.streamingAssetsPath, "Animal.csv");

    private void Init()
    {
        CSVLoader(DataType.Island);
        CSVLoader(DataType.Animal);
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
                        moneyDrop = CalculateAmount(bool.Parse(values[1]), int.Parse(values[0]), int.Parse(values[3])),
                        heartDrop = CalculateAmount(bool.Parse(values[1]), int.Parse(values[0]), int.Parse(values[3])),
                    };
                    if (island.unlockisland == false && nextIsland == null)
                        nextIsland = island;

                    islandDatas.Add(island);
                }
            }
            else
            {
                Debug.LogError("File not found: " + path);
            }
        }
        else if (type == DataType.Animal)
        {
            string path = animalDataPath;

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] values = line.Split(',');

                    AnimalData animal = new AnimalData
                    {
                        animalID = int.Parse(values[0]),
                        animalName = values[1],
                        unlockAnimal = bool.Parse(values[2]),
                        imagePath = values[3],
                        animalLevel = int.Parse(values[4]),
                        animalCount    = int.Parse(values[5]),
                        animalEffect   = int.Parse(values[6]),
                        price          = int.Parse(values[7]),
                    };
                    animalDatas.Add(animal);
                }
            }
            else
            {
                Debug.LogError("File not found: " + path);
            }
        }
    }

    private int CalculateAmount(bool isOpen, int id, int level)
    {
        if (!isOpen || level == 0) return 0;
        int pow = (int)Mathf.Pow(id*2+1, 2);
        return pow + pow / 100 * level;
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
        else if(type == DataType.Animal)
        {
            string path = animalDataPath;
            // CSV 파일의 헤더를 작성
            string header = "animalid,Name,unlock,ImagePath,level,count,effect,price";
            List<string> lines = new List<string> { header };

            // islandDatas 리스트의 각 IslandData를 CSV 형식으로 변환하여 추가
            foreach (var animal in animalDatas)
            {
                string line = $"{animal.animalID},{animal.animalName},{animal.unlockAnimal},{animal.imagePath},{animal.animalLevel},{animal.animalCount},{animal.animalEffect},{animal.price}";
                lines.Add(line);
            }

            // 기존의 StreamingAssets/Island.csv 파일에 덮어쓰기
            File.WriteAllLines(path, lines);
            Debug.Log("CSV file saved to " + path);
        }
    }

    public int GetIslandIndex(IslandData data)
    {
        for(int i = 0; i < islandDatas.Count; i++)
        {
            if (islandDatas[i] == data)
                return i;
        }

        return -1;
    }
}
