using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] DiscoverPanel _discoverPanel;
    [SerializeField] GameoverPanel _gameoverPanel;

    public static UIManager Instance
    {
        get 
        { 
            if(_instance == null)
            {
                _instance = Instantiate(Resources.Load<UIManager>("UICanvas"));
            }

            return _instance; 
        }
    }
    private static UIManager _instance = null;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);

        _instance = this;
    }

    //private void Start()
    //{
    //    Discover(EnemyType.Command);
    //}

    public void Gameover()
    {
        _gameoverPanel.InitGameoverPanel();
    }

    public void Discover(EnemyType type)
    {
        _discoverPanel.InitDiscoverPanel(type);
    }
}
