using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public GameObject deathEffect;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool shootMode = false;

	// Update is called once per frame
	void Update ()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			animator.SetBool("IsCrouching", true);
		} 
		
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			animator.SetBool("IsCrouching", false);
		}
		SetFireMode();
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void SetFireMode()
	{
		if(Input.GetButtonDown("ShootModeToggle") && shootMode == false)
		{
			animator.SetBool("ShootMode", true);
			shootMode = true;
		}
		else if (Input.GetButtonDown("ShootModeToggle") && shootMode == true)
		{
			animator.SetBool("ShootMode", false);
			shootMode = false;
		}
	}


}

