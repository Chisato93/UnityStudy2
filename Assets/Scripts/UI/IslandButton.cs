using UnityEngine;
using UnityEngine.UI;

public class IslandButton : MonoBehaviour
{
    public Button islandButton; // 버튼 컴포넌트를 연결합니다.
    public Enviroment environment; // Enviroment 인스턴스를 연결합니다.

    private void Start()
    {
        if (islandButton != null)
        {
            islandButton.onClick.AddListener(OnIslandButtonClick);
        }

        if (environment == null)
        {
            environment = FindObjectOfType<Enviroment>();
        }
    }

    public void OnIslandButtonClick()
    {
        // CSVSave와 UpdateIsland 함수를 호출합니다.
        DataManager.instance.CSVSave(DataType.Island); // 또는 DataType.Animal로 변경 가능
        environment.UpdateIsland();

        Debug.Log("CSV 저장 및 섬 업데이트 완료.");
    }
}
