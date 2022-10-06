using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public float canRestart = 3f;

    private void Update()
    {
        if (canRestart > 0)
        {
            canRestart -= Time.deltaTime;
        }
    }
    public void Restart() {

        if (canRestart <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            canRestart = 3f;
        }
    }
}
