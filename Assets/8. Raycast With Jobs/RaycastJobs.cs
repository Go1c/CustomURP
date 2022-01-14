using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastJobs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // public class DummyCrosshair : MonoBehaviour
    // {
    //   // ...
    //   private NativeArray<RaycastCommand> _raycastCommands;
    //   private NativeArray<RaycastHit> _raycastHits;
    //   private JobHandle _jobHandle;
    //
    //   void Awake()
    //   {
    //     _raycastCommands = new NativeArray<RaycastCommand>(1, Allocator.Persistent);
    //     _raycastHits = new NativeArray<RaycastHit>(1, Allocator.Persistent);
    //   }
    //
    //   private void OnDestroy()
    //   {
    //     _jobHandle.Complete();
    //     _raycastCommands.Dispose();
    //     _raycastHits.Dispose();
    //   }
    //
    //   void Update()
    //   {
    //     // 1. Process raycast from last frame
    //     _jobHandle.Complete();
    //     RaycastHit raycastHit = _raycastHits[0];
    //     bool didHitYa = raycastHit.collider != null;
    //     Color targetColor = Color.white;
    //     if (didHitYa)
    //     {
    //       if (raycastHit.collider.CompareTag("Player"))
    //       {
    //         targetColor = Color.green;
    //       }
    //       else if (raycastHit.collider.CompareTag("Enemy"))
    //       {
    //         targetColor = Color.red;
    //       }
    //     }
    //     _crosshairMaterial.SetColor("_Color", targetColor);
    //
    //     // 2. Schedule new raycast
    //     _raycastCommands[0] = new RaycastCommand(_cameraTransform.position, _cameraTransform.forward);
    //     _jobHandle = RaycastCommand.ScheduleBatch(_raycastCommands, _raycastHits, 1);
    //   }
    // }
}
