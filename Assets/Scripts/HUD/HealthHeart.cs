using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    [SerializeField] private Sprite fullHeart, halfHeart, emptyHeart;

    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            //Empty Heart
            case HeartStatus.Empyty:
                heartImage.sprite = emptyHeart;
                break;

            //Half Heart
            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;

            //Full Heart
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }
}

public enum HeartStatus
{
    Empyty = 0,
    Half = 1,
    Full = 2
}
