using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieAttack : MonoBehaviour
{
    private bool canDamage = false;
    private Collider col;
    private Animator bloodEffect;
    public int damageAmt = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
        bloodEffect = GameObject.Find("Blood").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(col.enabled == false)
        {
            canDamage = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(canDamage == true)
            {
                canDamage = false;
                SaveScript.health -= damageAmt;
                SaveScript.infection += damageAmt;
                bloodEffect.SetTrigger("blood");
            }
        }
    }
}
