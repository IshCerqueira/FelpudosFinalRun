using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosdoChefe : MonoBehaviour
{

    public int vidaChefe;
    public float velocidade;
    public bool existindo;


    private void Start()
    {
        velocidade = 4f;
        vidaChefe = 10;
        existindo = false;
    }

    public void AumentarVelocidade()
    {

        velocidade *= 2;
        Debug.Log(velocidade);
    }

    public void ReduzirVida()
    {
        vidaChefe--;
        Debug.Log(vidaChefe);
    }

    public void toogleExistindo()
    {
        existindo = !existindo; 
    }
}
