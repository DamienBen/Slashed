﻿using UnityEngine;
using System.Collections;



public class vilainControl : MonoBehaviour
{
	private 		float 				_speed = 1.0f;
	private			bool				_isLanded = true;
	private			bool				_wasHitted = false;
	public static 	bool				leftTrig = false;
	public static	bool				rightTrig = false;
	private			float				_grHorizontal = 0.0F;
	private			float				_grVertical = 0.0F;
	private			Animator 			_rightAnimator, _leftAnimator;
	private			Animator 			_vilainAnimator;


	void Start () 
	{

		_vilainAnimator = GetComponent<Animator>();
		if (transform.position.x > 1)
		{
			_speed *= -1;
			transform.Rotate (0, 180, 0);
		}
	}


	void Update () 
	{

		
	
		if (_isLanded)
		{
	
			if (_speed > 0)
					rigidbody2D.AddForce (new Vector2 (400, 0));
						else
				rigidbody2D.AddForce (new Vector2 (-400, 0));
		} 
		else if (_vilainAnimator.GetBool("vilainHit"))
		{
			_grHorizontal += 0.25F;
			_grVertical += 0.15F;

			if (_speed > 0)
				rigidbody2D.velocity = new Vector3(-12.4F + _grHorizontal, 2.9F - _grVertical, 0);
			else
				rigidbody2D.velocity = new Vector3(12.4F - _grHorizontal, 2.9F - _grVertical, 0);

			if (!playerControl.isStriking)
				rigidbody2D.AddForce (new Vector2 (0, 0));

		}
		else if (_vilainAnimator.GetBool("vilainStrike"))
		{

			if (PlayerState.State.isVulnerable)
			{
				PlayerState.State.isVulnerable = false;
				playerControl.life --;
			}
		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{


		if (col.gameObject.name != "groundGravity" && col.gameObject.name != "vilainRunZ(Clone)" && col.gameObject.name != "vilain2(Clone)")  
			_wasHitted = true;		
		else if (col.gameObject.name == "groundGravity")
			_isLanded = true;
	


	}


	void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.name == "player") 
		{
			
			
			_wasHitted = true;
			_isLanded = false;
			
			
			if (playerControl.isStriking) {
				
				leftTrig = false;
				rightTrig = false;								
				StartCoroutine (destroyVilain ());								
				_vilainAnimator.SetBool ("vilainStrike", false);

				
			} else {
				
				playerControl.playerAnimator.SetBool ("playerHit", true);
				PlayerState.State.isVulnerable = false;
				_vilainAnimator.SetBool ("vilainStrike", true);
				
			}
			
		} 
	}

	void OnTriggerEnter2D (Collider2D col)
	{


		if (col.gameObject.name == "trigRight") 
		{

			_rightAnimator = col.GetComponent<Animator>();
			_rightAnimator.SetBool("trigRight", true);	

			rightTrig = true;

		}
		else if (col.gameObject.name == "trigLeft") 
		{
			_leftAnimator = col.GetComponent<Animator>();
			_leftAnimator.SetBool("trigLeft", true);	

			leftTrig = true;

		}
		/*
		 * col.gameObject.name != "groundGravity"
		    && col.gameObject.name != "vilainRunZ(Clone)"  
		   && col.gameObject.name != "vilain2(Clone)"
		    && col.gameObject.name != "trigRight" 
		    && col.gameObject.name != "trigLeft
		 */

	

	}



	void datEject()
	{

		if (_speed < 0)
			_rightAnimator.SetBool("trigRight", false);		
		else
			_leftAnimator .SetBool("trigLeft", false);		
		
		rigidbody2D.isKinematic = true;
		
		playerControl.playerAnimator.SetBool("playerHit", false);
		_vilainAnimator.SetBool("vilainHit", true);
		gameObject.collider2D.enabled = false;


	}


	IEnumerator destroyVilain() 
	{

		datEject ();
		 
		playerControl.isStriking = false;
		yield return new WaitForSeconds(0.40f);
		playerControl.playerAnimator.SetBool("strikeFirst", false);
		playerControl.playerAnimator.SetBool("strike2", false);
		yield return new WaitForSeconds(0.45f);
	//	playerControl.playerAnimator.SetBool("strikeFirst", false);
	//	playerControl.playerAnimator.SetBool("strike2", false);
		Destroy(gameObject);
	}


}
