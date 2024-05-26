using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaAnda : MonoBehaviour
{
    public float velocidade;
    public int comeco;
    public Transform[] pontos;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pontos[comeco].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pontos[index].position) < 0.02f)
        {
            index++;
            if (index == pontos.Length)
            {
                index = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, pontos[index].position, velocidade * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
