using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeScript : MonoBehaviour
{
    bool dead = false;


    [SerializeField] AudioSource death;

    private void Update()
    {
        if (transform.position.y < -0.5f && !dead)
        {
            Die();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<playercontrols>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        
        death.Play();
        Invoke(nameof(ReloadLevel), 1.45f);
        dead = true;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

}
