using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public RectTransform startButton;

    public Ease startButtonEase;

    public Image fadeScreen;

    private void Start()
    {
        fadeScreen.DOFade(0, 2).OnComplete(() => {
            startButton.DOScale(2, 2).SetEase(startButtonEase).OnComplete(() =>
            {
                startButton.DOShakePosition(1, 20, vibrato: 100).SetLoops(-1);
            });
        });
    }

    public void LoadGame()
    {
        fadeScreen.DOFade(1, 2).OnComplete(() => {
            SceneManager.LoadScene("Game");
        });
        
    }
}
