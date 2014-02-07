using UnityEngine;
using System.Collections;

enum PlayerState
{
	left,
	right,
	hit
};

public class playerControl : MonoBehaviour
{

	private		PlayerState 		_playerState;
	private		Animator 			_strikeFirstAnimator;


	void Start () 
	{
		_playerState = PlayerState.right;
		_strikeFirstAnimator = GetComponent<Animator>();

	}


	

	void Update () 
	{
		//if(rigidbody2D.velocity.x != 0)

		/*if (vilainControl.leftTrig)
			Debug.Log ("LEFT");
		if (vilainControl.rightTrig)
			Debug.Log ("RIGHT");
*/

	
		if (!_strikeFirstAnimator.IsInTransition(0))
			_strikeFirstAnimator.SetBool("strikeFirst", false);
		if (Input.GetKeyDown ("left") && vilainControl.leftTrig)
		{
			if (_playerState != PlayerState.left)
				transform.Rotate (0, 180, 0);
			_strikeFirstAnimator.SetBool("strikeFirst", true);
			_playerState = PlayerState.left;
		//	rigidbody2D.AddForce(new Vector2 (-150000, 0));
			rigidbody2D.velocity = new Vector2 (-30, 0);
		}

	
		if (Input.GetKeyDown ("right") && vilainControl.rightTrig)
		{




			if (_playerState != PlayerState.right)
				transform.Rotate (0, 180, 0);
			_strikeFirstAnimator.SetBool("strikeFirst", true);
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
		//	Debug.Log (collision.gameObject.name );
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
