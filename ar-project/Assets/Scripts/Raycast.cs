using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private ARPlaneManager arPlaneManager;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var screenCenter = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        
        ARRaycastHit? hit = hits[0];
        
        target.position = hit.Value.pose.position;
    }
}
