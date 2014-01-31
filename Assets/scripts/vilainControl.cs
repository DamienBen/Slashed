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
		if (_isLanded)
		{
						
			if (_speed > 0)
					rigidbody2D.AddForce (new Vector2 (250, 0));
						else
				rigidbody2D.AddForce (new Vector2 (-250, 0));
		} 
		else
		{
			//making a raneg random coeficien for random
			_grHorizontal += 0.25F;
			_grVertical += 0.05F;

			if (_speed > 0)
			{
				rigidbody2D.velocity = new Vector3(-1.4F + _grHorizontal, 2.5F - _grVertical, 0);
				rigidbody2D.AddForce (new Vector2 (-400, 0));
			}
			else
			{
				rigidbody2D.velocity = new Vector3(1.4F - _grHorizontal, 2.5F - _grVertical, 0);
				rigidbody2D.AddForce (new Vector2 (400, 0));
			}
		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.name != "groundGravity" && col.gameObject.name != "vilain(Clone)") 
		{
			_wasHitted = true;
		
		} 
		else if (col.gameObject.name == "groundGravity")
		{
			_isLanded = true;
		}

	}



	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "trigRight") 
		{
			rightTrig = true;
			//need to animate trigger bar
		}
		else if (col.gameObject.name == "trigLeft") 
		{
			leftTrig = true;
		//need to animate trigger bar
		}

		if (col.gameObject.name != "groundGravity" && col.gameObject.name != "vilain(Clone)" && col.gameObject.name != "trigRight" && col.gameObject.name != "trigLeft") 
		{
			_wasHitted = true;
			leftTrig = false;
			rightTrig = false;
			StartCoroutine (destroyVilain());
			_isLanded = false;

		} 
	}

	IEnumerator destroyVilain() 
	{
		//rigidbody2D.isKinematic = true;
		gameObject.collider2D.enabled = false;
		yield return new WaitForSeconds(0.9f);
		Destroy(gameObject);
	}


}
