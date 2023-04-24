using TMPro;
using UnityEngine;

public class NormalResultsViewController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtFinalScore;

    private PlayerData _playerData;
    public void Init(PlayerData playerData)
    {
        _playerData = playerData;
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        txtFinalScore.text = _playerData.CurrentPlayerScore.ToString();
        gameObject.SetActive(true);
    }


   
}
