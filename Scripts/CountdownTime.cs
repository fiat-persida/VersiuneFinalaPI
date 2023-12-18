using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTime : MonoBehaviour
{ 

    [SerializeField] private Text _timerText;
    private float _currentTime;

    [SerializeField] private float _duration;


    void Start()
    {
        _currentTime = _duration;
        _timerText.text = _currentTime.ToString();
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while (_currentTime >= 0)
        {
            _timerText.text = _currentTime.ToString();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }

        // Timer reached 0, restart the level
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}