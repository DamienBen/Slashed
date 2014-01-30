using UnityEngine;
using System.Collections;




public class startBattle : MonoBehaviour 
{

	public 	GameObject 			vilain;	
	public 	GameObject 			background;
	public 	GameObject 			backgroundLeft;
	public 	GameObject			backgroundRight;
	public	float				backgroundWidth;
	public 	float 				speed = 10f;
	private	GameObject[]		_backgroundArray;
	private int					_currentBackground;
	public	GameObject			trigLeft;
	public	GameObject			trigRight;


	void Start ()
	{
		StartCoroutine (VilainSpawn());
		backgroundWidth = background.renderer.bounds.size.x;
		Vector3 v = new Vector3 (background.transform.position.x +backgroundWidth, background.transform.position.y, background.transform.position.z);
		Vector3 v2 = new Vector3 (background.transform.position.x - backgroundWidth, background.transform.position.y, background.transform.position.z);
		backgroundRight = (GameObject)Instantiate (background, v, Quaternion.identity);
		backgroundLeft = (GameObject)Instantiate(background, v2, Quaternion.identity);


		_currentBackground = 1;
		_backgroundArray = new GameObject[3];
		_backgroundArray [0] = backgroundLeft;
		_backgroundArray [1] = background;
		_backgroundArray [2] = backgroundRight;
	}

	void Update()
	{
		GameObject p = GameObject.Find ("player");
		transform.position = new Vector3 (p.transform.position.x, transform.position.y, transform.position.z);
		trigLeft.transform.position = new Vector3(p.transform.position.x - 2.5F, trigLeft.transform.position.y, trigLeft.transform.position.z);
		trigRight.transform.position = new Vector3(p.transform.position.x + 2.5F, trigLeft.transform.position.y, trigLeft.transform.position.z);
		InfiniteBackground ();
	

	}

	void InfiniteBackground()
	{
		int decalLeft = 0;
		int decalRight = 0;

		if (transform.position.x > _backgroundArray [_currentBackground].transform.position.x + backgroundWidth / 2) 
		{
			
			
			if (_currentBackground == 0) {
				decalLeft = 2;
				decalRight = 1;
				_currentBackground ++;
			} else if (_currentBackground == _backgroundArray.Length - 1) {
				decalLeft = 1;
				decalRight = 0;
				_currentBackground = 0;
			} else {
				decalLeft = _currentBackground - 1;
				decalRight = _currentBackground + 1;
				_currentBackground ++;
			}
			_backgroundArray [decalLeft].transform.position = new Vector3 (_backgroundArray [decalRight].transform.position.x + backgroundWidth, backgroundRight.transform.position.y);
			
		} 
		else if(transform.position.x < _backgroundArray [_currentBackground].transform.position.x - backgroundWidth / 2)
		{		
			
			if (_currentBackground == 0) {
				decalLeft = 2;
				decalRight = 1;
				_currentBackground = _backgroundArray.Length - 1;
			} else if (_currentBackground == _backgroundArray.Length - 1) {
				decalLeft = 1;
				decalRight = 0;
				_currentBackground --;
			} else {
				decalLeft = _currentBackground - 1;
				decalRight = _currentBackground + 1;
				_currentBackground --;
			}		
			_backgroundArray [decalRight].transform.position = new Vector3 (_backgroundArray [decalLeft].transform.position.x - backgroundWidth, backgroundRight.transform.position.y);
		}

	}

	IEnumerator VilainSpawn()
	{
		while(true)
		{
			int side = Random.Range(1,200) % 2;
			float sSide = transform.position.x + 20.0F;

			if (side == 1)
			{

				if (transform.position.x < 0)
					sSide = transform.position.x - 20; 
				else
					sSide *= -1;
			}
			Vector3 v = new Vector3(sSide,0,0);
			Instantiate (vilain, v, Quaternion.identity); 

			
			yield return new WaitForSeconds(0.8f);

		}
	}
}
