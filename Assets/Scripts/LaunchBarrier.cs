using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBarrier : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("pinball")) return;
        else boxCollider.isTrigger = false;
    }
}
