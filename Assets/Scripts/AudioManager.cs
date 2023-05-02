using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityOSC;

public class AudioManager : MonoBehaviour
{
    public int backGroundMetroSpeed;
    public int launchCharge;
    public int launchShoot;
    public float launchTimer;
    public bool didLaunch;

    public int phasorTracker;
    private int phasor;

    public bool collided;
    private float collidedTimer;

    void Awake()
    {
        Application.runInBackground = true;

        OSCHandler.Instance.Init();
    }

    private void Start()
    {
        backGroundMetroSpeed = 500;

        launchCharge = 800;
        launchShoot = 40;
        launchTimer = 1f;
        didLaunch = false;

        phasorTracker = 1;
        phasor = 0;

        collided = false;
        collidedTimer = 0.5f;

        OSCHandler.Instance.SendMessageToClient("pd", "/unity/background", 1);
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/metro", backGroundMetroSpeed);
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/charge", launchCharge);
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/phasor", phasor);

    }

    // FOR EDITOR QUIT ONLY (NOT PRODUCTION BUILD)
    private void OnApplicationQuit()
    {
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/background", 1);
    }

    private void Update()
    {
        if (collided)
        {
            if (collidedTimer > 0) collidedTimer -= Time.deltaTime;
            else DisableCollisionAudio();
        }

        if (phasorTracker % 5 == 0)
        {
            if (phasor < 10) IncrementPhasor();
            phasorTracker = 1;
        }

        if (!didLaunch) return;
        else
        {
            if (launchTimer > 0) launchTimer -= Time.deltaTime;
            else DisableShootAudio();
        }
    }

    public void UpdateBackGroundMetroSpeed(int nextValue)
    {
        backGroundMetroSpeed = nextValue >= 50 ? nextValue : 50;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/metro", backGroundMetroSpeed);
    }
    
    public void ToggleLaunchCharge(int value)
    {
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/triggerCharge", value);
    }    

    public void UpdateLaunchCharge(int nextValue)
    {
        launchCharge = nextValue >= 0 ? nextValue : 0;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/charge", launchCharge);
    }

    public void TriggerCollisionAudio()
    {
        if (collided) return;
        else collided = true;

        collidedTimer = 0.5f;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/collision", 1);
    }

    private void DisableCollisionAudio()
    {
        collided = false;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/collision", 0);
    }

    private void DisableShootAudio()
    {
        ToggleLaunchCharge(0);
        launchTimer = 1f;
        didLaunch = false;
    }

    private void IncrementPhasor()
    {
        phasor++;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/phasor", phasor);
    }
}
