using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int kills = 0;

    public void AlienDestroyed(){
        kills += 1;
        if (kills == 50)
            SceneManager.LoadScene(2);
    }
}
