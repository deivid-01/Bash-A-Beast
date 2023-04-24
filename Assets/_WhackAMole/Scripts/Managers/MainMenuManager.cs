using UnityEngine;
public class MainMenuManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private PlayerData playerData;
    [Space]
    
    [SerializeField] private HighScoreViewController highScoreViewController;
    [SerializeField] private ItemNotifier startGameplayNotifier;
    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private AudioSource backgroundAudio;
    private APIController ApiController=>APIController.Instance;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        ApiController.Init(gameConfig.BaseApiurl,gameConfig.PlayersRouteService,gameConfig.HighscoreValidationRouteService);

        playerData.Init(ApiController);
        playerData.UpdateData(DataLoaded);

        void DataLoaded(bool success)
        {
            if (!success) return;
            StartMainMenu();
        } 
    }
    private void StartMainMenu()
    {
        loadingCanvas.gameObject.SetActive(false);
        backgroundAudio.Play();
        highScoreViewController.Init(playerData);
        startGameplayNotifier.OnTriggered += StartGame;
    }
    private void StartGame()
    {
        startGameplayNotifier.OnTriggered -= StartGame;
        gameConfig.LoadGameplay();
    }
    private void OnDisable()
    {
        startGameplayNotifier.OnTriggered -= StartGame;
    }
}
