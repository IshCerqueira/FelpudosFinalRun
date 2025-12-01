using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptDoChefe : MonoBehaviour
{

    public Transform chefe;
    public GameObject projetilPrefab;
    public GameObject fogoPrefab;
    public Color newColor = Color.red;
    public SpriteRenderer spriteRenderer;
    public float limiteDestruicaoX = -12f;
    public float intervalo = 1.5f;
    public AudioSource src;
    public AudioClip die, entrance;


    [SerializeField] private DadosdoChefe _dadosDoChefe;
 

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        src = GameObject.Find("AudioSource2").GetComponent<AudioSource>();

        _dadosDoChefe = GameObject.Find("BossData").GetComponent<DadosdoChefe>();
        _dadosDoChefe.toogleExistindo();

        src.clip = entrance;
        src.Play();

        InvokeRepeating("Atirar", 0f, intervalo);

        StartCoroutine(Mover());
    }

    private void Update()
    {
        if(_dadosDoChefe.velocidade > 6)
        {
            spriteRenderer.color = newColor;
        }
    }


    IEnumerator Mover()
    {
         
            while (chefe.position.x > 0)
            {
                // Move o inimigo da direita para a esquerda
                chefe.transform.Translate(Vector2.left * 7 * Time.deltaTime);

                yield return null; // Espera o próximo frame

                if ((chefe.position.x < 0))
                {
                    yield return new WaitForSeconds(0.3f);
                    break;
                }
            }



        while (chefe.position.x < 0)
        {

            if (_dadosDoChefe.vidaChefe == 0)
            {
                src.clip = die;
                src.Play();

                _dadosDoChefe.velocidade = 0;

                Vector3 posicao = new Vector3(chefe.position.x, chefe.position.y, -0.5f);
                GameObject fogo = Instantiate(fogoPrefab, posicao, Quaternion.identity);

                yield return new WaitForSeconds(2.0f);

                gameObject.SetActive(false);

              
                
                SceneManager.LoadScene("FlappyCutScene2");

                break;
            }

            else 
            { 
                UpMove();

            yield return null; // Espera o próximo frame

            if (chefe.position.x < 0 && chefe.position.y >= 3)
            {
                break;
            }
        }   
        }

            while (chefe.position.x < 0)
            {
                 
            if (_dadosDoChefe.vidaChefe == 0)
            {

                src.clip = die;
                src.Play();

                _dadosDoChefe.velocidade = 0;

                Vector3 posicao = new Vector3(chefe.position.x, chefe.position.y, -0.5f);
                GameObject fogo = Instantiate(fogoPrefab, posicao, Quaternion.identity);

                yield return new WaitForSeconds(2.0f);

                gameObject.SetActive(false);

               
                
                SceneManager.LoadScene("FlappyCutScene2");

                break;


            }

            else
            {
                DownMove();

                yield return null; // Espera o próximo frame

                if (chefe.position.x < 0 && chefe.position.y <= -3)
                {
                    StartCoroutine(Mover());
                    break;
                }
            }
        }

             
        
    }

    public void UpMove()
    {
            chefe.transform.Translate(Vector2.up * _dadosDoChefe.velocidade * Time.deltaTime);   
    }

    public void DownMove()
    {
        chefe.transform.Translate(Vector2.down * _dadosDoChefe.velocidade * Time.deltaTime);
    }

    public void Atirar()
    {
        if (chefe.position.x < 0 && _dadosDoChefe.vidaChefe > 0)
        {
            Vector2 posicao = new Vector2(chefe.position.x - 1, chefe.position.y);

            // Instancia o inimigo
            GameObject projetil = Instantiate(projetilPrefab, posicao, Quaternion.identity);

            // Inicia o movimento automático (corrotina)
            StartCoroutine(MoverProjetil(projetil));
        }
         
    }

    IEnumerator MoverProjetil(GameObject projetil)
    {
        while (projetil != null)
        {
            // Move o inimigo da direita para a esquerda
            projetil.transform.Translate(Vector2.left * 5 * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (projetil.transform.position.x < limiteDestruicaoX)
            {
                Destroy(projetil);
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }

}
