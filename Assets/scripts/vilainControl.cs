using UnityEngine;
using System.Collections;

public class vilainControl : MonoBehaviour
{
	private 	float 				_speed = 0.08f;
	private 	float				_localGravity = 0.0F;
	private		bool				_applyGravity = true;
	
	void Start () 
	{
		if (transform.position.x > 1)
		{
			_speed *= -1;
			transform.Rotate (0, 180, 0);
		}
	}

	void Update () 
	{
	
		if (_applyGravity) 
			_localGravity -= 9.81f * Time.deltaTime;
		else
			_localGravity = 0;

		Vector3 tmp = new Vector3 (_speed, _localGravity * Time.deltaTime, 0);	
		transform.position += tmp;
		
		if (transform.position.y > 0.0f)
			_applyGravity = true;
		else
		{
			// WHY WITH POSITION > 0
			transform.position =  new Vector3(transform.position.x, 0, transform.position.z);

			}
		//Debug.Log (_localGravity);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		/*if(col.gameObject.name == "vilain")
		{}*/
	//		Destroy(col.gameObject);
		//rigidbody2D.AddForce(transform.forward * 100);
		if (col.gameObject.name == "groundGravity")
			_applyGravity = false;
		
		if (_speed > 0) 
			rigidbody2D.velocity = new Vector2 (-10, 1);
		else 
		{
			rigidbody2D.velocity = new Vector2 (10, 1);
		}
		//Debug.Log ("i hit" + col.gameObject.name );
	}


}
