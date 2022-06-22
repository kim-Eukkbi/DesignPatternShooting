using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameoverPanel : MonoBehaviour
{
    [SerializeField] Text textDie = null;
    [SerializeField] Button btnRestart;
    [SerializeField] Button btnExit;

    RectTransform myRect = null;

    private void Awake()
    {
        btnRestart.onClick.AddListener(() => SceneManager.LoadScene("MAIN"));
        btnExit.onClick.AddListener(() => Application.Quit());
    }

    public void InitGameoverPanel()
    {
        myRect = transform.GetComponent<RectTransform>();
        myRect.DOAnchorPosY(myRect.rect.height, 0f);
        textDie.color = new Color(textDie.color.r, textDie.color.g, textDie.color.b, 0);

        gameObject.SetActive(true);

        myRect.DOAnchorPosY(0, 5f).SetEase(Ease.OutBounce);
        textDie.DOFade(1, 3f);
    }
}
