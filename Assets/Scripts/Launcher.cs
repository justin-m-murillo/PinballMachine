using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] float launchSpeed;

    private GameControls gameControls;
    private Rigidbody rb;
    private float totalSpeed;
    private bool isCharging;

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
        ResetValues();
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
        rb.isKinematic = false;
        rb.AddForce(transform.forward * totalSpeed, ForceMode.Impulse);
        enabled = false;
    }

    public void ResetValues()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        totalSpeed = 0;
        isCharging = false;
    }
}
