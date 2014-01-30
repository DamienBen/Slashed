using UnityEngine;
using System.Collections;

public class vilainControl : MonoBehaviour
{
	private 	float 				_speed = 1.0f;
	private		bool				_isLanded = false;
	private		bool				_wasHitted = false;

	void Start () 
	{
		if (transform.position.x > 1)
		{
			_speed *= -1;
			transform.Rotate (0, 180, 0);
		}
	}

	void FixedUpdate () 
	{

		if (_speed > 0 && _isLanded)
			rigidbody2D.AddForce(new Vector2 (250, 0));
		else if (_isLanded)
			rigidbody2D.AddForce(new Vector2 (-250, 0));

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.name != "groundGravity" && col.gameObject.name != "vilain(Clone)") 
		{
			_wasHitted = true;
						if (_speed > 0 && _isLanded) {
				_isLanded = false;
								rigidbody2D.AddForce (new Vector2 (-3500, 1500));
						} else if (_isLanded) {
				_isLanded = false;
								rigidbody2D.AddForce (new Vector2 (3500, 1500));
						}
				} else if (col.gameObject.name == "groundGravity") {
					
			if (_wasHitted)
				Destroy(gameObject);
						_isLanded = true;
				}

	}



	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "trigRight") 
		{
			Debug.Log("ENEMY COME FROM RIGHT");
		}
		else if (col.gameObject.name == "trigLeft") 
		{
			Debug.Log("ENEMY COME FROM LEFT");
		}
		else if (col.gameObject.name != "groundGravity" && col.gameObject.name != "vilain(Clone)" && col.gameObject.name != "trigRight" && col.gameObject.name != "trigLeft") 
		{
			_wasHitted = true;
			if (_speed > 0 && _isLanded) {
				_isLanded = false;
				rigidbody2D.AddForce (new Vector2 (-4500, 1500));
			} else if (_isLanded) {
				_isLanded = false;
				rigidbody2D.AddForce (new Vector2 (4500, 1500));
			}
		} else if (col.gameObject.name == "groundGravity") {
			
			if (_wasHitted)
				Destroy(gameObject);
			_isLanded = true;
		}

			
			
		}

}
