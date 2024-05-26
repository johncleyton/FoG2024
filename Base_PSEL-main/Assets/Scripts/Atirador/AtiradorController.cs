using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiradorController : MonoBehaviour
{
    //Prefab para criar
    [SerializeField] private GameObject FlechaPrefab;
    //Intervalo entre as flehcasflehcas
    [SerializeField] private int tempoMin;
    [SerializeField] private int tempoMax;
    //Para saber quando pode atirar
    private float UltimoTiro;
    [SerializeField] public Vector3 vetor;
    private int intervaloRandom;

    void Start()
    {
        intervaloRandom = Random.Range(tempoMin, tempoMax);
        //Salva o momento em que a cena foi carregada, o tempo = 0 da cena
        UltimoTiro = Time.time;
    }

    void Update()
    {
        //Se o tempo é maior que o tempo do último tiro + o intervalo
        if(Time.time >= intervaloRandom + UltimoTiro)
        {
            //Cria uma rotação
            Quaternion rotacao = new Quaternion();
            //Define a rotação em função de graus (º)
            rotacao.eulerAngles = vetor;

            //Instancia a flecha apontando pra cima
            Instantiate(FlechaPrefab, transform.position, rotacao);

            intervaloRandom = Random.Range(tempoMin, tempoMax);
            //Salva o momento do tiro
            UltimoTiro = Time.time;
        }
    }
}
