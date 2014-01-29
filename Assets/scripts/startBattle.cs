using UnityEngine;
using System.Collections;

public class startBattle : MonoBehaviour 
{

	public 	GameObject vilain;
	public 	GameObject background;
	public 	GameObject backgroundLeft;
	public 	GameObject backgroundRight;
	public	float		backgroundWidth;
	public float speed = 10f;


	void Start ()
	{
		StartCoroutine (VilainSpawn());
		backgroundWidth = background.renderer.bounds.size.x;
		Vector3 v = new Vector3 (background.transform.position.x +backgroundWidth, background.transform.position.y, background.transform.position.z);
		Vector3 v2 = new Vector3 (background.transform.position.x - backgroundWidth, background.transform.position.y, background.transform.position.z);
		backgroundRight = (GameObject)Instantiate (background, v, Quaternion.identity);
		backgroundLeft = (GameObject)Instantiate(background, v2, Quaternion.identity);
	}

	void Update()
	{
		GameObject p = GameObject.Find ("player");
		transform.position = new Vector3 (p.transform.position.x, transform.position.y, transform.position.z);


	
		if (transform.position.x > 0) 
		{
			if (transform.position.x > backgroundRight.transform.position.x)
				backgroundLeft.transform.position = new Vector3(background.transform.position.x + backgroundWidth * 2,backgroundRight.transform.position.y );
		}
		else
		{
			if (transform.position.x < backgroundLeft.transform.position.x)
				backgroundRight.transform.position = new Vector3(background.transform.position.x - backgroundWidth * 2,backgroundLeft.transform.position.y );

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

			
			yield return new WaitForSeconds(4.6f);

		}
	}
}
