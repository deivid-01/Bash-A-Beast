using UnityEngine;
using UnityEngine.SceneManagement;

    [CreateAssetMenu(fileName = "GameConfig", menuName = "WhackAMole/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [Header("Main gameplay Config")] 
        [SerializeField] private int pointsByHit;
        [SerializeField] private float roundDurationInSeconds;
        [Header("Scene Config")]
        [SerializeField] private string mainSceneName;
        [SerializeField] private string gameplaySceneName;
        [Header("API Config")]
        [SerializeField] private string baseAPIURL;
        [SerializeField] private string playersRouteService;
        [SerializeField] private string highscoreValidationRouteService;

        public string BaseApiurl => baseAPIURL;

        public string PlayersRouteService => playersRouteService;

        public string HighscoreValidationRouteService => highscoreValidationRouteService;
        public int PointsByHit => pointsByHit;
        public float RoundDurationInSeconds => roundDurationInSeconds;
        public void LoadGameplay() => LoadNoAdditiveScene(gameplaySceneName);
        public void LoadManinMenu() => LoadNoAdditiveScene(mainSceneName);
        public void LoadCurrentScene() => LoadNoAdditiveScene(SceneManager.GetActiveScene().name);
        private void LoadNoAdditiveScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
