using UnityEngine;

public class HighScoreResultsViewController : MonoBehaviour
{
    [SerializeField] private HighScoreSaverView highScoreSaverView;
    [SerializeField] private HighScoreFinalMsgView msgView;
    public void Init(PlayerData playerData)
    {
        highScoreSaverView.Init(playerData);
        msgView.Init(playerData);
    }
    public void Enable()
    {
        gameObject.SetActive(true);
        highScoreSaverView.OnSavePlayer+=HandleSavePlayer;
        highScoreSaverView.Enable();
        msgView.Disable();
    }
    private void OnDisable()
    {
        highScoreSaverView.OnSavePlayer-=HandleSavePlayer;
    }
    private void HandleSavePlayer()
    {
        highScoreSaverView.Disable();
        msgView.Enable();
    }
    public void Disable()
    {
        gameObject.SetActive(false);
        
    }
}
