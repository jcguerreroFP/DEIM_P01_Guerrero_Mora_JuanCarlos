using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameUI : MonoBehaviour
{
    public Image fadeScreen;

    public Ease fadeEase;

    void Start()
    {
        fadeScreen.DOFade(0, 2).SetEase(fadeEase);
    }
}
