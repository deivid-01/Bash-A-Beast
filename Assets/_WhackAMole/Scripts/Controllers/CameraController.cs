using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     private Camera _camera;

     public Camera Camera => _camera;

     public void Init()
     {
          _camera = GetComponent<Camera>();
     }
}
