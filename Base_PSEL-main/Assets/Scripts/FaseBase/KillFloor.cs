using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica se colidiu com o jogador
        if (collision.collider.tag == "Player")
        {
            //Se sim, avisa o controlador do jogo que ele morreu
            GameObject.FindGameObjectWithTag("Controlador").GetComponent<ControladorDoJogo>().Morreu();

        }
    }
}
