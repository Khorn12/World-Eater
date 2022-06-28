using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
public string loadLevel;




public void Load ()
{
    SceneManager.LoadScene(loadLevel);
}
}