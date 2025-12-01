using UnityEngine;
using System.Collections;

public class MoveFofura: MonoBehaviour
{
	public Vector3 moveSpeed, alternativeMoveSpeed;
	public float spawnTime = 2f;
	public float spawnDelay = 2f;
	public bool leftMoving = true, stopMoving = false;
	// Use this for initialization
	void Start()
	{
		moveSpeed = Vector3.left * Time.deltaTime;
		alternativeMoveSpeed = Vector3.right * Time.deltaTime;
		InvokeRepeating("ChangeSpeed", spawnDelay, spawnTime);
	}

	void ChangeSpeed()
	{
		moveSpeed = new Vector3(Random.Range(-1, -2), 0, 0) * 0.01f;
		alternativeMoveSpeed = new Vector3(Random.Range(1, 2), 0, 0) * 0.01f;
    }

	private void Flip()
	{
		  
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;

	 
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Reverse")
        {
            leftMoving = !leftMoving;
			Flip(); 
		}

		if (other.gameObject.tag == "Player")
		{
			stopMoving = true;
		}
	 
	}

	// Update is called once per frame
	void Update()
	{
		 

		if (stopMoving == false){
			if (leftMoving)
			{
				transform.position += moveSpeed;
			}
			else if (!leftMoving)
			{
				transform.position += alternativeMoveSpeed;
			}
		}
        
	}
}