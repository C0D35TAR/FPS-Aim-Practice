using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public LayerMask groundLayers;

    public float jumpForce = 7f;

    public CapsuleCollider col;

    private Rigidbody rb;
    private PlayerController playerController;

	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    col = GetComponent<CapsuleCollider>();
	    playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		PerformJump();
	}

    void PerformJump()
    {
        if (IsGrounded() && Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
        
    }
}
