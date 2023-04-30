using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] float torqueStrength;

    protected GameControls gameControls;
    private Rigidbody rb;

    private void Awake()
    {
        gameControls = new GameControls();
    }

    private void OnEnable()
    {
        gameControls.Enable();
    }

    protected void Flipper_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        rb.AddTorque(Vector3.up * torqueStrength, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        gameControls.Disable();
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = Mathf.Infinity;
    }
}
