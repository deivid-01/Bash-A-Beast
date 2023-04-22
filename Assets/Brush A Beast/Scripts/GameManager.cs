using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private APIController apiController;
    [SerializeField] private GameData gameData;

    [ContextMenu("StartGame")]
    private void StartGame()
    {
        gameData.Init(apiController);
        gameData.UpdateData(DataLoaded);

        void DataLoaded(bool success)
        {
            print("Data ready, game stared!");
        }
    }

}
