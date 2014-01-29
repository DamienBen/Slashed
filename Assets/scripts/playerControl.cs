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
	private		float				_playerDestination = 0.0F;
	private 	float				_localGravity = 0.0F;
	private		bool				_applyGravity = true;


	void Start () 
	{
		_playerState = PlayerState.right;
	}

	

	void Update () 
	{
		//if(rigidbody2D.velocity.x != 0)


		if (Input.GetKeyDown ("left"))
		{
			if (_playerState != PlayerState.left)
				transform.Rotate (0, 180, 0);

			_playerState = PlayerState.left;
		//	rigidbody2D.AddForce(new Vector2 (-150000, 0));
			rigidbody2D.velocity = new Vector2 (-30, 0);
		}

		if (Input.GetKeyDown ("right"))
		{
			if (_playerState != PlayerState.right)
				transform.Rotate (0, 180, 0);

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
			collision.gameObject.rigidbody2D.velocity = new Vector2 (10000, 0);
		//	collision.gameObject.rigidbody2D.AddForce(new Vector2(3000,100));
		
		}*/
		//	rigidbody2D.AddForce(transform.forward * 100);
		
		//	Destroy(collision.gameObject);	
		
		
		
	}




	
}
