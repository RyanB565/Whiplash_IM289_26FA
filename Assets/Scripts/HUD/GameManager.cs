using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScriptableObject skeleton;
    public ScriptableObject zombie;

    public Canvas deathcanvas;



    [SerializeField] private TextMeshProUGUI deathText;


    private PlayerController controller;

    public int EnemiesKilled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<PlayerController>();

        EnemiesKilled = 0;

        deathcanvas.enabled = false;

       
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }

    public void PickupCount()
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
