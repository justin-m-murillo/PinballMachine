using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperRight : Flipper
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        gameControls.PlayerInput.RightFlipper.performed += Flipper_performed;
    }
}
