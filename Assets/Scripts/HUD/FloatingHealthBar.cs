
using UnityEngine;
using UnityEngine.UI;


public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 barPositionOffset;

    private void Start()
    {
        mainCamera = FindFirstObjectByType<Camera>();
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        healthbarSlider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = mainCamera.transform.rotation;
        transform.position = target.position + barPositionOffset;
    }
}
