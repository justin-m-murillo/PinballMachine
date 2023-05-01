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
        else SetBoxColliderTrigger(false);
    }

    /// <summary>
    /// Whether to set this object's box collider to isTrigger
    /// </summary>
    /// <param name="value">True to enable isTrigger, false to disable isTrigger</param>
    public void SetBoxColliderTrigger(bool value)
    {
        boxCollider.isTrigger = value;
    }
}
