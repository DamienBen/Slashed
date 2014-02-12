using UnityEngine;
using System.Collections;

enum PlayerState
{
	left,
	right

};

public class playerControl : MonoBehaviour
{

	private					PlayerState 		_playerState;
	public 	static			Animator 			playerAnimator;
	public	static			bool				isStriking;	



	void Start () 
	{

		playerControl.isStriking = false;
			_playerState = PlayerState.right;
		playerAnimator = GetComponent<Animator>();

	}



	void Update () 
	{

		//		Debug.Log (_strikeFirstAnimatorhit.GetCurrentAnimatorStateInfo(0).IsTag("strikeFirst"));
	
	/*	if (!playerAnimator.IsInTransition (0)) 
			playerAnimator.SetBool ("strikeFirst", false);
	*/	

		if (playerAnimator.GetBool("strikeFirst"))
			transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
		else
			transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);

		if (Input.GetKeyDown ("left") && vilainControl.leftTrig)
		{
			playerControl.isStriking = true;
			if (_playerState != PlayerState.left)
				transform.Rotate (0, 180, 0);
			playerAnimator.SetBool("strikeFirst", true);
			_playerState = PlayerState.left;
		//	rigidbody2D.AddForce(new Vector2 (-150000, 0));
			rigidbody2D.velocity = new Vector2 (-30, 0);
		}

	
		if (Input.GetKeyDown ("right") && vilainControl.rightTrig)
		{
			playerControl.isStriking = true;
			if (_playerState != PlayerState.right)
				transform.Rotate (0, 180, 0);
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
			playerAnimator.SetBool("strikeFirst", true);
			_playerState = PlayerState.right;
			rigidbody2D.velocity = new Vector2 (30, 0);
		//	rigidbody2D.AddForce(new Vector2 (150000, 0));

		}




		//controller.attachedRigidbody.AddExplosionForce (10.0f, transform.position, 5.0f, 3.0f);
	}


		
		
	void OnCollisionEnter2D (Collision2D collision)
		{

			rigidbody2D.velocity = new Vector2 (0, 0);
	//	Debug.Log (collision.gameObject.name );
		/*if (collision.gameObject.name != "groundGravity")
		{
			collision.gameObject.rigidbody2D.velocity = new Vector2 (10000, 0);
		//	collision.gameObject.rigidbody2D.AddForce(new Vector2(3000,100));
		
		}*/
	//	rigidbody2D.AddForce(transform.forward * 100);

		//	Destroy(collision.gameObject);	



	}


void OnTriggerEnter2D (Collider2D collision)
	{

		rigidbody2D.velocity = new Vector2 (0, 0);

		//Debug.Log (transform.position.x + "/" + collision.gameObject.transform.position.x);

		if (!playerAnimator.GetBool("strikeFirst"))
		{
			if (transform.position.x > collision.gameObject.transform.position.x)
			{
				if (_playerState != PlayerState.left)
					transform.Rotate (0, 180, 0);
				_playerState = PlayerState.left;
			}
			else
			{
				if (_playerState != PlayerState.right)
					transform.Rotate (0, 180, 0);
				_playerState = PlayerState.right;
			}
				
		}

		/*if (collision.gameObject.name != "groundGravity")
		{
			//collision.transform.gameObject.rigidbody2D.velocity = new Vector3(-50, 30, 0);
			//collision.gameObject.rigidbody2D.velocity = new Vector2 (10000, 0);
		//	collision.gameObject.rigidbody2D.AddForce(new Vector2(3000,100));
		
		}*/
		//	rigidbody2D.AddForce(transform.forward * 100);
		
		//	Destroy(collision.gameObject);	
		
		
		
	}




	
}
