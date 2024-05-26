using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnGravidade : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.gravityScale = -Player.gravityScale;
            Player.transform.RotateAround(Player.transform.position, Player.transform.right, 180f);
        }
    }
}
