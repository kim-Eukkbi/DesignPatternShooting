using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DiscoverPanel : MonoBehaviour
{
    static DiscoverDiary diary = null;

    [SerializeField] CanvasGroup cg = null;

    [SerializeField] Text textPatternName = null;
    [SerializeField] Text textPatternInfo = null;

    [SerializeField] Button btnResume = null;

    [SerializeField] DesignPatternSO patternListSO = null;

    [SerializeField] Image[] desginPatternImages = null;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();

        btnResume.onClick.AddListener(() => 
        {
            cg.DOFade(0f, 2f).SetUpdate(true).OnComplete(() =>
            {
                gameObject.SetActive(false);
                Time.timeScale = 1f;
            });
        });
    }

    public void InitDiscoverPanel(EnemyType type)
    {
        Time.timeScale = 0f;
        cg.alpha = 0;

        gameObject.SetActive(true);
        cg.DOFade(1f, 2f).SetUpdate(true);
        desginPatternImages[(int)type].gameObject.SetActive(true);
        textPatternName.text = patternListSO.designPatternInfoList[(int)type].desginPatternName;
        textPatternInfo.text = patternListSO.designPatternInfoList[(int)type].infomation;

    }
}

public enum EnemyType
{
    Pool,
    Singleton,
    Command
}

[System.Serializable]
public class DiscoverDiary
{
    public List<int> listDiscoverdIdx = new List<int>();
}
