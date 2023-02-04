using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject _panelPause;
    public GameObject _buttonPause;
    public UnityEngine.EventSystems.EventSystem _eventSystem;

    private void Start()
    {
        _eventSystem = FindObjectOfType<UnityEngine.EventSystems.EventSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            ActivePauseMenu(!_panelPause.active);
        }
    }

    public void ActivePauseMenu(bool active)
    {
        _panelPause.SetActive(active);

        if (active)
        {
            Time.timeScale = 0;
            _eventSystem.firstSelectedGameObject = _buttonPause;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
