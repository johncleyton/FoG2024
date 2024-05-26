using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuantosColetados : MonoBehaviour
{
    public int quantidade = 0;
    [SerializeField] public int qtdeMax;

    public void Somar()
    {
        quantidade++;
    }

    public void CarregarCena()
    {
        if (qtdeMax == 6)
        {
            if (quantidade >= qtdeMax)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
            if (quantidade >= qtdeMax)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}
