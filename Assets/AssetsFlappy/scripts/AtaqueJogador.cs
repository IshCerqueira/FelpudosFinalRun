using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{
    // Prefab do inimigo (arraste no Inspector)
    public GameObject tiroPrefab;
    public Transform jogador;
    // Intervalo entre spawns (segundos)
    public float intervalo = 3f;
    public bool disparandoAgora;


    // Velocidade de movimento dos tiros
    public float velocidade = 0;

    // Limite X para destruir o inimigo ao sair da tela
    public float limiteDestruicaoX;

    private void Start()
    {
        disparandoAgora = false;
        velocidade = 15f;
    }


    void Update()
    {

        if (Input.GetButtonDown("Fire2") && !disparandoAgora)
        {

           
                disparandoAgora = true;
                Vector2 posicaoDeSurgimento = new Vector2(jogador.position.x + 2f, jogador.position.y);

                // Instancia o inimigo
                GameObject disparo = Instantiate(tiroPrefab,posicaoDeSurgimento, Quaternion.identity);

                limiteDestruicaoX = posicaoDeSurgimento.x + 9;

                // Inicia o movimento automático (corrotina)
                StartCoroutine(MoverProjetil(disparo));
           

        }

    }

    IEnumerator MoverProjetil(GameObject disparo)
    {
        while (disparo != null)
        {
            
            // Move o projetil da esquerda para direita
            disparo.transform.Translate(Vector2.right * velocidade * Time.deltaTime);
           
            // Após um tempo sem atingir destroi o disparo
            if (disparo.transform.position.x > limiteDestruicaoX)
            {
                Destroy(disparo);
                disparandoAgora = false;

                yield break; // Sai da corrotina
              
            }
            
            
            yield return null; // Espera o próximo frame
        }

        if(disparo == null)
        {
            disparandoAgora = false;
        }
    
        
    }
}
