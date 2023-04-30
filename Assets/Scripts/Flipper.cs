using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [SerializeField] float torqueStrength;

    protected GameControls gameControls;
    public bool flipExecuted;
    private Rigidbody rb;

    private void Awake()
    {
        gameControls = new GameControls();
    }

    private void OnEnable()
    {
        gameControls.Enable();
    }

    protected void Flipper_performed(InputAction.CallbackContext context)
    {
        flipExecuted = true;
        rb.AddTorque(Vector3.up * torqueStrength, ForceMode.Impulse);
    }

    protected void Flipper_canceled(InputAction.CallbackContext context)
    {
        flipExecuted = false;
    }

    private void OnDisable()
    {
        gameControls.Disable();
    }

    protected virtual void Start()
    {
        flipExecuted = false;
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = Mathf.Infinity;
    }
}
