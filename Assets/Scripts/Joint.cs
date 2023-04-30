using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [SerializeField] Rigidbody flipperRigidbody;

    FixedJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = gameObject.AddComponent<FixedJoint>();    
        joint.connectedBody = flipperRigidbody;
    }
}
