using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasController : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject[] balaPrefabs;
    private int index = 0;
    [SerializeField] public float[] cooldowns;
    private float[] cooldownTimers;

    private void Start()
    {
        cooldownTimers = new float[cooldowns.Length];
        for (int i = 0; i < cooldownTimers.Length; i++)
        {
            cooldownTimers[i] = Mathf.Infinity;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cooldownTimers[index] >= cooldowns[index])
            {
                cooldownTimers[index] = 0f;
                Instantiate(balaPrefabs[index], firePoint.position, transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            index++;
            if (index >= balaPrefabs.Length)
                index = 0;
        }

        for (int i = 0; i < cooldownTimers.Length; i++)
            cooldownTimers[i] += Time.deltaTime;
    }

}