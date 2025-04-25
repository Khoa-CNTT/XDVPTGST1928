using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieAttack : MonoBehaviour
{
    private bool canDamage = false;
    private Collider col;
    private Animator bloodEffect;
    public int damageAmt = 3;
    private AudioSource hitSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
        bloodEffect = GameObject.Find("Blood").GetComponent<Animator>();
        hitSound = GetComponent<AudioSource>();
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
                if(SaveScript.health > 0)
                {
                    SaveScript.health -= damageAmt;
                }
                if(SaveScript.infection < 100)
                {
                    SaveScript.infection += damageAmt;
                }
                
                bloodEffect.SetTrigger("blood");
                hitSound.Play();
            }
        }
    }
}
