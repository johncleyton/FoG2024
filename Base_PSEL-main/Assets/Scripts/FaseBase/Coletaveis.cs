using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coletaveis : MonoBehaviour
{
    [SerializeField] private GameObject coletavel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(coletavel);
            GameObject.FindGameObjectWithTag("Player").GetComponent<QuantosColetados>().Somar();
            GameObject.FindGameObjectWithTag("Player").GetComponent<QuantosColetados>().CarregarCena();
        }
    }
}
