using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    [SerializeField] public float velocidade;
    private Rigidbody2D Bala;
    [SerializeField] private int index;

    // Start is called before the first frame update
    void Start()
    {
        Bala = GetComponent<Rigidbody2D>();
        Bala.velocity = transform.right * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bala"))
        {
            if (collision.gameObject.CompareTag("Destruivel"))
            {
                Destroy(collision.gameObject);
            }

            if (index == 2 && collision.gameObject.CompareTag("Gravitacional"))
            {
                Rigidbody2D gravitacional = collision.gameObject.GetComponent<Rigidbody2D>();
                gravitacional.gravityScale = -gravitacional.gravityScale;
            }

            if (index == 1 && collision.gameObject.CompareTag("Inimigo"))
            {
                Destroy(collision.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
