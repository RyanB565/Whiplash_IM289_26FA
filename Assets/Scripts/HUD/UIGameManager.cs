#if UNITY_EDITOR
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    private SoulAttack aoeAttack;

    [SerializeField] private TextMeshPro slashAttack;
    [SerializeField] private TextMeshPro soulAttack;
    [SerializeField] private TextMeshPro speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aoeAttack = FindFirstObjectByType<SoulAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void statsInfo()
    {

    }
}
