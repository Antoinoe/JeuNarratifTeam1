using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeToHub : MonoBehaviour
{
    [SerializeField] string sceneName;
    bool hasTouchedScreen = false;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //transi?
            if (!hasTouchedScreen)
            {
                hasTouchedScreen = true;
                //transi tempête de sable?
                SceneManager.LoadScene(sceneName);
            }
                
        }
    }
}
