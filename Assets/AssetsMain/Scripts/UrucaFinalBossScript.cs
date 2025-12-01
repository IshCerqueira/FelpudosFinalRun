using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UrucaFinalBossScript : MonoBehaviour
{
    public GameObject projetilPrefabEsquerda;
    public GameObject projetilPrefabDireita;
    public float limiteDestruicaoX = -7f;
    public float intervalo = 1.5f;
    public SpriteRenderer spriteRenderer;
    public int flipProjetil = -1;
    public int vidaDoChefe = 10;
    public Color newColor = Color.red;


    [SerializeField] private GameObject Player;

    void Start()
    {
        vidaDoChefe = 10;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BossMoveSet());
    }

    private void Update()
    {
        if (vidaDoChefe == 5)
        {
            spriteRenderer.color = newColor;
        }
    }


    IEnumerator BossMoveSet()
    {
        yield return new WaitForSeconds(1);
        AtirarDireita();
        yield return new WaitForSeconds(1);
        AtirarDireita();
        yield return new WaitForSeconds(1);
        AtirarDireita();
        flipProjetil *= -1;
        yield return new WaitForSeconds(3);
        gameObject.transform.position = new Vector2(-8.22f, -3.12f);
        spriteRenderer.flipX = true;
        StartCoroutine(BossMoveSet2());
    }

    IEnumerator BossMoveSet2()
    {
        yield return new WaitForSeconds(1);
        AtirarEsquerda();
        yield return new WaitForSeconds(1);
        AtirarEsquerda();
        yield return new WaitForSeconds(1);
        AtirarEsquerda();
        flipProjetil *= -1;
        yield return new WaitForSeconds(3);
        gameObject.transform.position = new Vector2(8.22f, -3.12f);
        spriteRenderer.flipX = false;
        StartCoroutine(BossMoveSet());
        yield return null;
    }

    public void AtirarDireita()
    {

       
        Vector2 posicao = new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y);

        // Instancia o inimigo
        GameObject projetil = Instantiate(projetilPrefabEsquerda, posicao, Quaternion.identity);

         
            // Inicia o movimento automático (corrotina)
            StartCoroutine(MoverProjetilRightToLeft(projetil));
      
        

    }

    public void AtirarEsquerda()
    {


        Vector2 posicao2 = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);

        // Instancia o inimigo
        GameObject projetil2 = Instantiate(projetilPrefabDireita, posicao2, Quaternion.identity);

            // Inicia o movimento automático (corrotina)
            StartCoroutine(MoverProjetilLeftToRight(projetil2));
        


    }

    IEnumerator MoverProjetilRightToLeft(GameObject projetil)
    {
        while (projetil != null)
        {
            // Move o inimigo da direita para a esquerda
            projetil.transform.Translate(Vector2.left * 5 * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (projetil.transform.position.x <=  limiteDestruicaoX)
            {
                Destroy(projetil);
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }

    IEnumerator MoverProjetilLeftToRight(GameObject projetil2)
    {
        while (projetil2 != null)
        {
            // Move o inimigo da direita para a esquerda
            projetil2.transform.Translate(Vector2.right * 5 * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (projetil2.transform.position.x >= - limiteDestruicaoX)
            {
                Destroy(projetil2);
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vidaDoChefe--;
            Player.transform.position = new Vector2(Player.transform.position.x, 1f); 

            if(vidaDoChefe == 0)
            {
                SceneManager.LoadScene("FinalBossWinScene");
            }

        }
    }




}
