using UnityEngine;

public class MoleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private AudioSource hitSoundEffect;
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

    public void GetHit(Vector3 hitPoint, Vector3 hitNormal)
    {
        GameObject particle=Instantiate(hitEffect.gameObject, hitPoint, Quaternion.LookRotation(hitNormal));
        Destroy(particle,1f);
        hitSoundEffect.pitch = Random.RandomRange(0.9f, 1.2f);
        hitSoundEffect.volume = Random.RandomRange(0.8f, 1f);
        hitSoundEffect.Play();
        _moleAnimatorController.HideMole();
    }

    public void StartBehavior() => _moleAnimatorController.ShowMole();

    public void StopBehavior() => _moleAnimatorController.Stop();
}
