using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float Velocidade;
    [SerializeField] private Transform PeDoPersonagem;
    [SerializeField] private Transform FrenteDoPersonagem;
    [SerializeField] private LayerMask Chao;
    [SerializeField] private LayerMask Plataforma;
    [SerializeField] private LayerMask Parede;


    //O corpo do jogador
    [SerializeField] private Rigidbody2D Corpo;
    //Para ele não pular infinitamente
    private bool PodePular = false;
    private bool DoubleJump = true;
    [SerializeField] private float ForcaPulo;
    [SerializeField] private float ForcaDash;
    private bool PodeDash = true;

    [SerializeField] float coyoteTime = 0.2f;
    [SerializeField] float coyoteTimeCounter = 0.2f;

    void Update()
    {
        float movimento_horizontal;
        //Define a velocidade do corpo baseada na tecla pressionada (Input.GetAxisRaw("Horizontal"))
        //A função retorna 1 se a seta pra direita ou D foram pressionados
        //Retorna -1 se a seta da esquerda ou A foram pressionados
        //Retorna 0 se nenhum direcional foi pressionado

        if (Input.GetKey(KeyCode.LeftControl))
            movimento_horizontal = (float)(Velocidade * Input.GetAxisRaw("Horizontal") * 1.5);
        else
            movimento_horizontal = Velocidade * Input.GetAxisRaw("Horizontal");

        //Neste caso, não se usa Time.deltaTime, porque RigidBody2D.velocity já opera baseado na taxa de frames
        Corpo.velocity = new Vector2(movimento_horizontal, Corpo.velocity.y);

        if (Corpo.gravityScale > 0)
        {
            if (movimento_horizontal > 0)
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            else if (movimento_horizontal < 0)
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Corpo.gravityScale < 0)
        {
            if (movimento_horizontal > 0)
                transform.rotation = Quaternion.Euler(180f, 0f, 0f);
            else if (movimento_horizontal < 0)
                transform.rotation = Quaternion.Euler(180f, 180f, 0f);
        }

        //Cria uma caixa, se a caixa colidir com o chao, pode pular
        //Nessa função se passa a posição, tamanho, angulo e distancia(tamanho) em relação a direção
        //Tambem passa um layer mask, pra que somente os layers associados a Chao sejam considerados
        bool PertoDoChao = Physics2D.BoxCast(PeDoPersonagem.position, new Vector2(0.5f, 0.2f), 0f, Vector2.down, 0.1f, Chao);
        bool PertoPlataforma = Physics2D.BoxCast(PeDoPersonagem.position, new Vector2(0.5f, 0.2f), 0f, Vector2.down, 0.1f, Plataforma);

        //Se o acerto tem um resultado não nulo, pode pular
        if (PertoDoChao || PertoPlataforma)
        {
            coyoteTimeCounter = coyoteTime;
            PodePular = true;
            PodeDash = true;
        }
        else //Caso contrário, não se pode pular
        {
            coyoteTimeCounter -= Time.deltaTime;
            PodePular = false;
        }

        //Se a barra de espaço foi pressionada e o jogador pode pular
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0)
        {
            // Verifica em que estado está o jogador, com gravidade invertida ou não
            if (Corpo.gravityScale > 0)
                Corpo.AddForce(Vector2.up * ForcaPulo);
            else
                Corpo.AddForce(Vector2.down * ForcaPulo);
            // Coyote Time
            coyoteTimeCounter = 0f;
            DoubleJump = true;
            PodePular = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && (PodePular || DoubleJump))
            {
                Corpo.velocity = Vector3.zero;
                if (DoubleJump && !PodePular)
                {
                    // Verifica em que estado está o jogador, com gravidade invertida ou não
                    if (Corpo.gravityScale > 0)
                        Corpo.AddForce(Vector2.up * ForcaPulo);
                    else
                        Corpo.AddForce(Vector2.down * ForcaPulo);
                    DoubleJump = false;
                }
            }
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Só vai dar dash quando o jogador estiver em movimento
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if (PodeDash)
                {
                    Corpo.velocity = Vector3.zero;
                    Vector2 vetor = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    Corpo.AddForce(vetor * ForcaDash);
                    PodeDash = false;
                }
            }
        }


        // Bullet Time
        if (Time.timeScale > 0)
        { 
            if (Input.GetKey(KeyCode.E))
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
        }

    }
}
