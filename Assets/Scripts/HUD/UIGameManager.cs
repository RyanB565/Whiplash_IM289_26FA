using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIGameManager : MonoBehaviour
{
    [Header("Attack Prefabs")]
    [SerializeField] private GameObject slashPrefab;
    [SerializeField] private GameObject soulPrefab;

    private AttackDamage slashDamage;
    private AttackDamage soulDamage;

    [Header("Player Speed Stats")]
    [SerializeField] private PlayerController playerController;

    [Header("UI")]
    [SerializeField] private GameObject statsPage;
    [SerializeField] private TextMeshProUGUI slashAttack;
    [SerializeField] private TextMeshProUGUI soulAttack;
    [SerializeField] private TextMeshProUGUI speed;
    private InputAction openStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openStats = InputSystem.actions.FindAction("Stats");

        openStats.performed += OpenStatsPreformed;
        openStats.canceled += OpenStatsCanceled;

        slashDamage = slashPrefab.GetComponent<AttackDamage>();
        soulDamage = soulPrefab.GetComponent<AttackDamage>();

        statsPage.gameObject.SetActive(false);
    }

    private void OpenStatsCanceled(InputAction.CallbackContext obj)
    {
        statsPage.gameObject.SetActive(false);
    }

    private void OpenStatsPreformed(InputAction.CallbackContext obj)
    {
        statsPage.gameObject.SetActive(true);
        statsInfo();
    }

    public void statsInfo()
    {
        slashAttack.text = $"Slash Damage: {playerController.SlashDamage}";
        soulAttack.text = $"Soul Damage: {playerController.SoulDamage}";
        speed.text = $"Speed: {playerController.Speed}";
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
}
