using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    public int blueFireId;
    public GameObject explosionParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainFireController.instance.ActiveFire(blueFireId, true);
            MainFireController.instance.TpPlayer();

            GameObject particle = Instantiate(explosionParticle, transform.position, Quaternion.identity);

            particle.GetComponent<ParticleSystem>().Play();
            Destroy(particle, 1);

            gameObject.SetActive(false);
        }
    }
}