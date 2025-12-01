using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMainSelectScript : MonoBehaviour
{

	private float horizontal;
	private float speed;
	private float jumpingPower;
	private bool isFacingRight;
	private bool interactable = false;
	private bool interactionTime = false;
	public int vidaDoJogador;

	[SerializeField] private Image imageSelector;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Sprite[] imageBox;


	void Start()
	{
		vidaDoJogador = 4;
		speed = 5f;
		jumpingPower = 6f;
		isFacingRight = true;
	
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

		if(Input.GetButtonDown("Fire1") && interactable)
        {
			ToggleInteractionTime();
		}

		Flip();
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	private void Flip()
	{
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0)
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;

		}
	}


	public void LifeUIUpdate()
	{
		switch (vidaDoJogador)
		{
			case 0:
				imageSelector.sprite = imageBox[0];
				break;
			case 1:
				imageSelector.sprite = imageBox[1];
				break;
			case 2:
				imageSelector.sprite = imageBox[2];
				break;
			case 3:
				imageSelector.sprite = imageBox[3];
				break;
			case 4:
				imageSelector.sprite = imageBox[4];
				break;
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Inimigo")
		{
			vidaDoJogador--;
			Destroy(other.gameObject);
			LifeUIUpdate();

			if (vidaDoJogador == 0)
			{
				SceneManager.LoadScene("FinalBossGameOver");
			}

		}

	}




	public bool GetInteractionTime()
	{
		return interactionTime;
	}

	public void ToggleInteractionTime()
	{
		interactionTime = !interactionTime;
	}

	public bool GetInteract()
	{
		return interactable;
	}
	public void ToggleInteract()
	{
		interactable = !interactable;
	}



}
