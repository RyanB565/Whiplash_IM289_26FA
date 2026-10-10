#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas deathcanvas;
    [SerializeField] private TextMeshProUGUI deathText;

    private PlayerController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<PlayerController>();

        deathcanvas.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }

    public void PlayerDeath()
    {
        controller.deathStop();
        Time.timeScale = 0f;
        deathcanvas.enabled = true;  
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Ending()
    {
        ReloadScene();
        Debug.Log("Playing game agian!");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
