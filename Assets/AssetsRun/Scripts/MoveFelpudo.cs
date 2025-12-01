using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFelpudo : MonoBehaviour
{
	private float horizontal;
	private float speed;
	private float jumpingPower;
	private bool isFacingRight;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private GameObject winParticles;
	[SerializeField] private AudioSource src;
	[SerializeField] private AudioClip loveBirds;

	void Start()
	{
		speed = 3f;
		jumpingPower = 6f;
		isFacingRight = true;
		winParticles.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		if (Input.GetButtonDown("Jump") && IsGrounded())
		{

			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
	 

		}

		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{

			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}

		Flip();
	}

    private void FixedUpdate()
    {
		rb.velocity= new Vector2(horizontal * speed, rb.velocity.y);
    }

	private bool IsGrounded()
    {
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

	private void Flip()
    {
		if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0)
        {
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;

		}
    }

    void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "WinCon")
		{
			src.clip = loveBirds;
			src.Play();
			winParticles.SetActive(true);
			StartCoroutine(DelayedAction());

		}

    }

	IEnumerator DelayedAction()
	{
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("RunEndGame");

	}



}