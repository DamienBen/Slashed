﻿using UnityEngine;
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
	private		float		_tempPos = 2.0F;
	private		Vector3 v = new Vector3(2, 0, 0);

	void Start () 
	{
		_playerState = PlayerState.right;
	}
	

	void Update () 
	{
		CharacterController controller = GetComponent<CharacterController>();
		_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		_moveDirection = transform.TransformDirection(_moveDirection);
		_moveDirection *= _speed;

	


		//Debug.Log(transform.position.x);
	//	float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
	//	float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;
	//	transform.Translate(x,0,0/*y*/,/*Space.Self*/0);
	

		if (Input.GetKeyDown ("left"))
		{
			if (_playerState != PlayerState.left)
			{
				transform.Rotate (0, 180, 0);
				v.x *= -1;
			}
			_playerState = PlayerState.left;
			_tempPos -= 2;



		//	_moveDirection.x -=  100;
		//	transform.Translate(2, 0, 0, Space.Self);

		}
		if (Input.GetKeyDown ("right"))
		{
			if (_playerState != PlayerState.right)
			{
				transform.Rotate (0, 180, 0);
				v.x *= -1;
			}
			_playerState = PlayerState.right;
			_tempPos += 2;


		//	_moveDirection.x +=  100;
		//	transform.Translate(2, 0, 0, Space.Self);	
		}


		if (_playerState == PlayerState.right) {
						if (transform.position.x <= _tempPos)
								controller.Move (v * Time.deltaTime);
		}
		else
		{
			if (transform.position.x >= _tempPos)
				controller.Move (v * Time.deltaTime);
		}


		print (transform.position.x + "/" + _tempPos + "/" + v.x );
	}
}
