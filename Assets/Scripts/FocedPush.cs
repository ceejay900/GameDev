using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocedPush : MonoBehaviour
{
    //reference the RIgidBody from Player!
    public Rigidbody2D myNewRigidBody;
    public float horizontal;
    public float vertical;
    public void ForcedToJump()
    {
        myNewRigidBody.velocity = new Vector2(horizontal, vertical);
    }
}
