using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoPlataforma : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Plataforma;
    [SerializeField] private Collider2D Collider;
    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {       
            Destroy(Plataforma.gameObject, 2.0f);
            Plataforma.gravityScale = 1.0f;
            Collider.enabled = false;
        }
    }
}
