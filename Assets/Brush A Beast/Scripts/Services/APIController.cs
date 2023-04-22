using System;
using UnityEngine;


public class APIController : MonoBehaviour
{
    [SerializeField] private string BASE_API_URL;
    [SerializeField] private string PLAYERS_ROUTE;
    
    private GetPlayersWebService _getPlayersWebService;
    private CreatePlayerWebService _createPlayerWebService;

    private string URL;
    private Coroutine _getPlayerCoroutine;
    private Coroutine _addPlayerCoroutine;

    [ContextMenu("GetPlayers")]

    public void Init()
    {
        URL = BASE_API_URL + PLAYERS_ROUTE;
        
        _getPlayersWebService = GetComponent<GetPlayersWebService>();
        _createPlayerWebService = GetComponent<CreatePlayerWebService>();
        
        _getPlayersWebService.Init(URL);
        _createPlayerWebService.Init(URL);
    }
    public void GetPlayers(Action<bool,Player[]> OnSuccess)
    {
        _getPlayersWebService.GetPlayers(OnSuccess);
    }
    
    [ContextMenu("AddPlayer")]
    public void AddPlayer(Player newPlayer)
    {
        _createPlayerWebService.AddPlayer(newPlayer);
    }



    
    

    
}
