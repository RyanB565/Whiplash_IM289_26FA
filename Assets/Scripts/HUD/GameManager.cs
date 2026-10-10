using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas deathcanvas;

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
        Debug.Log("Playing death called");
        deathcanvas.enabled =true;
        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Ending()
    {
        ReloadScene();
        Debug.Log("Playing game agian!");

    }

    public void UiMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
