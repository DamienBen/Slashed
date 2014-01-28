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
	private		Vector3				_playerMove = Vector3.zero;
	private 	float				_localGravity = 0.0F;
	private		bool				_applyGravity = true;


	void Start () 
	{
		_playerState = PlayerState.right;
		_playerMove = new Vector3(20, 0, 0);
	}

	

	void Update () 
	{


		if (Input.GetKeyDown ("left"))
		{
			if (_playerState != PlayerState.left)
			{
				transform.Rotate (0, 180, 0);
				_playerMove.x *= -1;
			}
			_playerState = PlayerState.left;
			_playerDestination = -0.1F;

		}

		if (Input.GetKeyDown ("right"))
		{
			if (_playerState != PlayerState.right)
			{
				transform.Rotate (0, 180, 0);
				_playerMove.x *= -1;
			}
			_playerState = PlayerState.right;
			_playerDestination = 0.1F;

		}

		if (_applyGravity) 
			_localGravity -= 9.81f * Time.deltaTime;
		else
			_localGravity = 0;

		Vector3 tmp = new Vector3 (_playerDestination, _localGravity * Time.deltaTime, 0);	
		transform.position += tmp;

		if (transform.position.y > 0.0f)
			_applyGravity = true;
		else
			transform.position =  new Vector3 (transform.position.x, 0, transform.position.z);
		//controller.attachedRigidbody.AddExplosionForce (10.0f, transform.position, 5.0f, 3.0f);
	}



	void OnCollisionEnter2D (Collision2D collision)
	{
	//	Debug.Log (collision.gameObject.name );
		if (collision.gameObject.name == "groundGravity")
			_applyGravity = false;
	//	rigidbody2D.AddForce(transform.forward * 100);
//		rigidbody2D.velocity = new Vector2(10, 10);
		//	Destroy(collision.gameObject);	

	}


	
}
