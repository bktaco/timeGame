using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    public void LoadNextLevel()
    {
        GameManager.LoadNextLevel();
    }
}
