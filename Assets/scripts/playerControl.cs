using UnityEngine;
using System.Collections;

namespace PlayerState
{
	class State
	{
		public 	static 	bool	 	isVulnerable = true; 
	};
}


enum PlayerSide
{
	left,
	right
};





public class playerControl : MonoBehaviour
{
	private					PlayerSide 			_playerSide;
	public 	static			Animator 			playerAnimator;
	public	static			bool				isStriking;	
	public	static			int					life;
	public	static			bool				isVulnerable;
	public 					float 				updateInterval;
	private 				double 				_lastInterval;
	public	static			string				strikeName = "strikeFirst";
	private					float				_datTimerStop = 0;
	public					GameObject			camz;

	
	public float shake_decay;
	public float shake_intensity;
	public Vector3 originPosition;
	public Quaternion originRotation;

	
	void Start () 
	{
		updateInterval = 0.65f;
		_lastInterval = Time.realtimeSinceStartup;
		playerControl.life = 5;
		playerControl.isStriking = false;
		_playerSide = PlayerSide.right;
		playerAnimator = GetComponent<Animator>();

	}



	void Update () 
	{

	
		if(shake_intensity > 0){
			camz.transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			camz.transform.rotation = new  Quaternion(
				originRotation.x + Random.Range(-shake_intensity,shake_intensity)*0.2f,
				originRotation.y + Random.Range(-shake_intensity,shake_intensity)*0.2f,
				originRotation.z + Random.Range(-shake_intensity,shake_intensity)*0.2f,
				originRotation.w + Random.Range(-shake_intensity,shake_intensity)*0.2f);
			shake_intensity -= shake_decay;
		}


	
		 if (!playerControl.playerAnimator.GetBool("playerHit") && _datTimerStop > Time.realtimeSinceStartup)
			Time.timeScale = 0.2f;
		else
			Time.timeScale = 1.0f;
	/*	if (playerAnimator.GetBool(playerControl.strikeName))
			transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
		else*/
			transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);

		if (Input.GetKeyDown ("left") && (vilainControl.leftTrig || vilain2Control.leftTrig ))
		{
			Time.timeScale = 1.0f;
			playerControl.playerAnimator.SetBool("strikeFirst", false);
			playerControl.playerAnimator.SetBool("strike2", false);
			if (playerControl.strikeName == "strikeFirst")
				playerControl.strikeName = "strike2";
			else
				playerControl.strikeName = "strikeFirst";
			playerControl.isStriking = true;
			if (_playerSide != PlayerSide.left)
				transform.Rotate (0, 180, 0);
			playerAnimator.SetBool(playerControl.strikeName, true);
			_playerSide = PlayerSide.left;
		//	rigidbody2D.AddForce(new Vector2 (-150000, 0));
			rigidbody2D.velocity = new Vector2 (-30, 0);
		}

	
		if (Input.GetKeyDown ("right") &&  (vilainControl.rightTrig || vilain2Control.rightTrig ))
		{
			Time.timeScale = 1.0f;
			playerControl.playerAnimator.SetBool("strikeFirst", false);
			playerControl.playerAnimator.SetBool("strike2", false);

			if (playerControl.strikeName == "strikeFirst")
				playerControl.strikeName = "strike2";
			else
				playerControl.strikeName = "strikeFirst";
			playerControl.isStriking = true;
			if (_playerSide != PlayerSide.right)
				transform.Rotate (0, 180, 0);


			transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
			playerAnimator.SetBool(playerControl.strikeName, true);
			_playerSide = PlayerSide.right;
			rigidbody2D.velocity = new Vector2 (30, 0);
		//	rigidbody2D.AddForce(new Vector2 (150000, 0));

		}

		if (!PlayerState.State.isVulnerable) 
		{
			float timeNow = Time.realtimeSinceStartup;
			if (timeNow >= _lastInterval + updateInterval) 
			{
				PlayerState.State.isVulnerable = true;
				_lastInterval = timeNow;
			}
		}
		//controller.attachedRigidbody.AddExplosionForce (10.0f, transform.position, 5.0f, 3.0f);
	}


		
		
	void OnCollisionEnter2D (Collision2D collision)
		{
			rigidbody2D.velocity = new Vector2 (0, 0);
			
	
	}

	void Shake(){
		originPosition = camz.transform.position;
		originRotation = camz.transform.rotation;
		shake_intensity = 0.01f;
		shake_decay = 0.002f;
	}


	void OnTriggerStay2D (Collider2D col)
	{
		rigidbody2D.velocity = new Vector2 (0, 0);
		if (playerControl.isStriking)
		{
			_datTimerStop = Time.realtimeSinceStartup + 0.4f;
			Shake ();
		//	Time.timeScale = 1.0f;
		}
	}

void OnTriggerEnter2D (Collider2D collision)
	{
		rigidbody2D.velocity = new Vector2 (0, 0);

		//Debug.Log (transform.position.x + "/" + collision.gameObject.transform.position.x);

	
		if (!playerAnimator.GetBool(playerControl.strikeName))
		{
			if (transform.position.x > collision.gameObject.transform.position.x)
			{
				if (_playerSide != PlayerSide.left)
					transform.Rotate (0, 180, 0);
				_playerSide = PlayerSide.left;
			}
			else
			{
				if (_playerSide != PlayerSide.right)
					transform.Rotate (0, 180, 0);
				_playerSide = PlayerSide.right;
			}
				
		}
		else
		{
			//string attackState = "vikingHit";
			//playerAnimator.Play(attackState);

			_datTimerStop = Time.realtimeSinceStartup + 0.4f;
			Shake ();

			//Time.timeScale = 1.0f;
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
