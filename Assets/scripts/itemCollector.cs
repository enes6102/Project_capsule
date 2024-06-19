using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    [SerializeField] AudioSource coinCollectSound;

    int coins = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            coinCollectSound.Play();

        }
    }

}
