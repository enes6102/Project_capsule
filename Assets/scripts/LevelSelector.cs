using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level 01");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level 02");
    }
}
