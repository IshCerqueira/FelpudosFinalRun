using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DadosDoJogador : MonoBehaviour
{

    [SerializeField] private GeradorInimigos _geradorInimigos;

    public int vidaDoJogador;
    public int score;
    public TextMeshProUGUI countText;
    public AudioSource src;
    public AudioClip takingDamage;

    [SerializeField] private Image[] barraDeVida;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        vidaDoJogador = 5;
        score = 0;
    }

    public void AtualizaVida()
    {
        for (int i = 0; i < barraDeVida.Length; i++)
        {
            if(i < vidaDoJogador)
            {
                barraDeVida[i].enabled = true;
            }
            else
            {
               barraDeVida[i].enabled = false;
            }
        }
    }

    public void AumentarScore()
    {
        if (score < 10)
        {
            score++;
            SetCountText();

            if (score == 10)
            {
                _geradorInimigos.GerarChefe();

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        src.clip = takingDamage;
        src.Play();

        if (other.gameObject.tag == "Inimigo")
        {
            vidaDoJogador--;
            Destroy(other.gameObject);
            AtualizaVida();

            if(vidaDoJogador == 1) {
                SceneManager.LoadScene("GameOverFlappy");
            }

        }

        if (other.gameObject.tag == "KillBox")
        {
         SceneManager.LoadScene("GameOverFlappy");
        }


    }

    void SetCountText()
    {
        countText.text = score.ToString() + "/10";

    }
}
