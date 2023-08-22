using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float animTime;
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        animTime -= Time.deltaTime;
        if (animTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
