using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scene;

    private float timeCount;
    const int timeLimit = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (scene != "Transition")
        {
            timeCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scene != "Transition")
        {
            timeCount += Time.deltaTime;
            if (timeCount > timeLimit) LoadScene(scene);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadScene(scene);
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
