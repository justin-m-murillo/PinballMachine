using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    [SerializeField] int audioSpeedChange;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindWithTag("audioManager").GetComponent<AudioManager>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("bumper")) return;
        else audioManager.UpdateBackGroundMetroSpeed(audioSpeedChange);
    }
}
