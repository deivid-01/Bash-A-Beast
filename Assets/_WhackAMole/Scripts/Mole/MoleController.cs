using UnityEngine;

public class MoleController : MonoBehaviour
{
    [SerializeField] private  Collider hitDetectionCollider;
    private MoleAnimationController _moleAnimatorController;
    public void Init()
    {
        _moleAnimatorController = GetComponent<MoleAnimationController>();
        _moleAnimatorController.Init();
        _moleAnimatorController.OnHideShow += EnableDisableHitDirection;
        hitDetectionCollider.enabled = false;
    }
    private void OnDisable() => _moleAnimatorController.OnHideShow -= EnableDisableHitDirection;

    private void EnableDisableHitDirection() => hitDetectionCollider.enabled =  !hitDetectionCollider.enabled;

    public void GetHit() => _moleAnimatorController.HideMole();

    public void StartBehavior() => _moleAnimatorController.ShowMole();

    public void StopBehavior() => _moleAnimatorController.Stop();
}
