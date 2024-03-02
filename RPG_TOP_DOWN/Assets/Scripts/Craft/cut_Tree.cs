using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cut_Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;
    [SerializeField] private ParticleSystem leafs;

    private bool isCut;
    // Start is called before the first frame update
   

    public void Onhit()
    {

        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();
        if (treeHealth == 0){
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
                //Create a code to KNOW IF THE woodPrefab is instatiated
                         

                
            }
            // Create the cuted tree
            anim.SetTrigger("cut");
            isCut = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            Onhit();
        }
    }
}
