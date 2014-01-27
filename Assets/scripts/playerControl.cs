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

	private		PlayerState _playerState;
	private 	Vector3 	_moveDirection = Vector3.zero;
	private		float		_speed = 5.0F;
	private		float		_playerDestination = 0.0F;
	private		Vector3		_playerMove = Vector3.zero;


	void Start () 
	{
		_playerState = PlayerState.right;
		_playerMove = new Vector3(20, 0, 0);
	}
	

	void Update () 
	{
		CharacterController controller = GetComponent<CharacterController>();
	
		if (Input.GetKeyDown ("left"))
		{
			if (_playerState != PlayerState.left)
			{
				transform.Rotate (0, 180, 0);
				_playerMove.x *= -1;
			}
			_playerState = PlayerState.left;
			_playerDestination -= 1;

		}
		if (Input.GetKeyDown ("right"))
		{
			if (_playerState != PlayerState.right)
			{
				transform.Rotate (0, 180, 0);
				_playerMove.x *= -1;
			}
			_playerState = PlayerState.right;
			_playerDestination += 1;

		}


		if (_playerState == PlayerState.right) 
		{
			if (transform.position.x < _playerDestination)
				controller.Move (_playerMove * Time.deltaTime);
		}
		else
		{
			if (transform.position.x >= _playerDestination)
				controller.Move (_playerMove * Time.deltaTime);
		}


		print (transform.position.x + "/" + _playerDestination + "/" + _playerMove.x );
	}
}
