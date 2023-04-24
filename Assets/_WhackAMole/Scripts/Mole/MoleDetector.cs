using System;
using UnityEngine;

public class MoleDetector : MonoBehaviour
{
  
    [SerializeField] private LayerMask targetLayerMask;
    private CameraController _targetCamera;
   
    /*
    public void Init(GameplayCamerasManager gameplayCamerasManager, CameraController targetCamera,IInputDeviceController inputTrigger)
    {
        _gameplayCamerasManager = gameplayCamerasManager;
        _targetCamera = targetCamera;
        _inputTrigger = inputTrigger;
        _inputTrigger.OnStarted += TryDoRaycast;
    }
    */

    public void Init(CameraController cameraController)
    {
        _targetCamera = cameraController;
    }
    
    public void TryDoRaycast(Vector2 screenPosition,Action OnHit)
    {
        bool colliderDetected = DoRaycastAt(screenPosition, _targetCamera.Camera, out var hit);

        if (!colliderDetected) return;
        
        if(!hit.collider.TryGetComponent(out MoleController moleController))return;
            
        moleController.GetHit();
        OnHit?.Invoke();
    }

    private bool DoRaycastAt(Vector2 screenPosition, Camera foundCamera, out RaycastHit hit)
    {
        Ray ray = foundCamera.ScreenPointToRay(screenPosition);
        bool colliderDetected = Physics.Raycast(ray, out hit, 1000,targetLayerMask);
       
        DebugDrawRay(colliderDetected,ray,hit);
        
        return colliderDetected;
    }
    
    private void DebugDrawRay(bool success,Ray ray, RaycastHit hit)
    {
        if(success)
            Debug.DrawRay(ray.origin,ray.direction*hit.distance,Color.green);
        else
            Debug.DrawRay(ray.origin,ray.direction*1000,Color.red);
    }
}
