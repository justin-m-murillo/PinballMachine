using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] float launchSpeed;

    private GameControls gameControls;
    private float totalSpeed;
    private float chargeTime;
    private bool isCharging;
    private bool didLaunch;

    private void Awake()
    {
        gameControls = new GameControls();
    }

    private void OnEnable()
    {
        gameControls.Enable();

        gameControls.PlayerInput.LaunchPinball.started += LaunchPinball_started;
        gameControls.PlayerInput.LaunchPinball.canceled += LaunchPinball_canceled;
    }

    private void OnDisable()
    {
        gameControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        chargeTime = 0;
        isCharging = false;
        didLaunch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCharging) return;

        totalSpeed += launchSpeed * Time.deltaTime;
    }

    private void LaunchPinball_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isCharging = true;
    }

    private void LaunchPinball_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isCharging = false;
        didLaunch = true;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * totalSpeed, ForceMode.Impulse);
        enabled = false;
    }
}
