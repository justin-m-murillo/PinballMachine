using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperLeft : Flipper
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        gameControls.PlayerInput.LeftFlipper.performed += Flipper_performed;
        gameControls.PlayerInput.LeftFlipper.canceled += Flipper_canceled;
    }
}
