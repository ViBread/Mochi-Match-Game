using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInformer : MonoBehaviour
{   
    public bool WasCombinedIn {  get; set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasCollided && !WasCombinedIn)
        {
            Debug.Log("hascollided or was combinedin");
            _hasCollided = true;
            ThrowMochiController.instance.CanThrow = true;
            ThrowMochiController.instance.SpawnAMochi(MochiSelector.instance.NextMochi);
            MochiSelector.instance.PickNextMochi();
            Destroy(this);
        }
    }
}
