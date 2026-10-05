using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI deathText;

    private PlayerController controller;

    public int EnemiesKilled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<PlayerController>();

        EnemiesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        controller.deathStop();
        ReloadScene();
        Debug.Log("Playing death called");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
