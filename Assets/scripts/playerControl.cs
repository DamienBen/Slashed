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
	public 		float speed = 2120;


	void Start () 
	{
		_playerState = PlayerState.right;
	}
	

	void Update () 
	{
		Debug.Log(transform.position.x);


	//	float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
	//	float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;
	//	transform.Translate(x,0,0/*y*/,/*Space.Self*/0);
	

		if (Input.GetKeyDown ("left") && _playerState != PlayerState.left)
		{
			_playerState = PlayerState.left;		
			transform.Rotate (0, 180, 0);
		//	transform.Translate( - (Vector3.left * 100.0f * Time.smoothDeltaTime));

			//a test
			/*
			transform.position = new Vector3(0, 0, 0);
			print(transform.position.x);
			*/
		}
		if (Input.GetKeyDown ("right") && _playerState != PlayerState.right)
		{
			_playerState = PlayerState.right;
			transform.Rotate (0, 180, 0);
		//	transform.Translate(Vector3.right * 100.0f * Time.smoothDeltaTime );
		//	transform.position = new Vector3(1, 0, 0f);
	
		}
	}
}
