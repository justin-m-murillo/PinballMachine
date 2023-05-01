using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityOSC;

public class AudioManager : MonoBehaviour
{
    public int backGroundMetroSpeed;

    void Awake()
    {
        Application.runInBackground = true;

        OSCHandler.Instance.Init();
    }

    private void Start()
    {
        backGroundMetroSpeed = 500;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/background", 1);
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/metro", backGroundMetroSpeed);
    }

    public void UpdateBackGroundMetroSpeed(int value)
    {
        int nextSpeed = backGroundMetroSpeed + value;
        backGroundMetroSpeed = nextSpeed > 0 ? nextSpeed : 25;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/metro", backGroundMetroSpeed);
    }
}
