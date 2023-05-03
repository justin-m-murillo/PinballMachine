using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] GameObject pinball;
    [SerializeField] Transform pinballSpawner;
    [SerializeField] LaunchBarrier barrier;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindWithTag("audioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("pinball")) return;
        else other.transform.position = pinball.transform.position;

        other.transform.rotation = pinball.transform.rotation;
        Launcher launcher = other.GetComponent<Launcher>();
        launcher.enabled = true;
        launcher.ResetValues();
        barrier.SetBoxColliderTrigger(true);

        audioManager.ResetCollisionInc();
    }
}
