using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vida : MonoBehaviour
{
    [SerializeField] private int vida;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flecha"))
        {
            vida--;
            Destroy(collision.gameObject);
            if (vida <= 0)
                GameObject.FindGameObjectWithTag("Controlador").GetComponent<ControladorDoJogo>().Morreu();
        }
    }
}
