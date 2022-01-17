using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class RaycastJobs : MonoBehaviour
{
    private NativeArray<RaycastCommand> _raycastCommands;
    private NativeArray<RaycastHit> _raycastHits;
    private JobHandle _jobHandle;
    public TextMeshProUGUI text;
    void Awake()
    {
        _raycastCommands = new NativeArray<RaycastCommand>(1, Allocator.Persistent);
        _raycastHits = new NativeArray<RaycastHit>(1, Allocator.Persistent);
    }

    private void OnDestroy()
    {
        _raycastCommands.Dispose();
        _raycastHits.Dispose();
        _jobHandle.Complete();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _jobHandle.Complete();
        RaycastHit hit = _raycastHits[0];
        bool isHit = hit.collider != null;
        if (isHit)
        {
            if (hit.transform.name == "Red")
            {
                text.color = Color.red;
            }
            else if (hit.transform.name == "Blue")
            {
                text.color = Color.blue;
            }
        }
        _raycastCommands[0] = new RaycastCommand(Camera.main.transform.position, Camera.main.transform.forward);
        _jobHandle = RaycastCommand.ScheduleBatch(_raycastCommands, _raycastHits, 1);
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