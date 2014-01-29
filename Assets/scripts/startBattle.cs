using UnityEngine;
using System.Collections;

public class startBattle : MonoBehaviour 
{

	public 	GameObject vilain;
	public 	GameObject background;
	public float speed = 10f;


	void Start ()
	{
		StartCoroutine (VilainSpawn());
	}

	void Update()
	{
		GameObject p = GameObject.Find ("player");
		transform.position = new Vector3 (p.transform.position.x, transform.position.y, transform.position.z);
		//Instantiate(background, v2, Quaternion.identity);

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
			Vector3 v2 = new Vector3(-20, 3, 0);

			Instantiate (vilain, v, Quaternion.identity); 

			
			yield return new WaitForSeconds(4.6f);

		}
	}
}
