using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character; // Reference to the character GameObject.
    public Vector3 jointPosition = new Vector3(0, 0, 5); // Position of the joint relative to the haptic manipulator.
    public Vector3 connectPoint = new Vector3(0, 0, 0); // Position on the character's Rigidbody where the joint will be attached.

    void Start()
    {
        Rigidbody characterRigidbody = character.GetComponent<Rigidbody>();

        if (characterRigidbody == null)
        {
            Debug.LogError("Character GameObject must have a Rigidbody component.");
            return;
        }

        ConfigurableJoint joint = gameObject.AddComponent<ConfigurableJoint>();
        joint.connectedBody = characterRigidbody;

        // Set the anchor position of the joint in the local space of the haptic manipulator.
        joint.anchor = jointPosition;

        // Set the connected anchor position on the character's Rigidbody in its local space.
        joint.connectedAnchor = connectPoint;

        // Set the motion mode for each axis to Limited.
        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.yMotion = ConfigurableJointMotion.Limited;
        joint.zMotion = ConfigurableJointMotion.Limited;

        // Configure the linear limits for each axis.
        SoftJointLimit linearLimit = new SoftJointLimit();
        linearLimit.limit = 0.005f; // Adjust the limit as needed for minimal movement.
        linearLimit.bounciness = 0.0f; // Optional: Set the bounciness if you want bouncing behavior.
        joint.linearLimit = linearLimit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
