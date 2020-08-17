using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;
using UnityEngine.SceneManagement;


public class GoToNextScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject text;
    public GameObject wheel;
    public string SceneToLoad = "";
    public float MinLoadTime = 4.5f;
    public bool ShouldEngineSoundPlay;

    private AsyncOperation _asy;
    private AudioManager _audManager;
    private float _bgAnimTime = 1f;
    private float _timeElapsed = 0f;
    private bool _isLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        _audManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isLoading)
        {
            if(_timeElapsed > _bgAnimTime && !wheel.activeInHierarchy)
            {
                wheel.SetActive(true);
                text.SetActive(true);

                if (ShouldEngineSoundPlay)
                {
                    _audManager.playSound("Start_Menu_Engine_Starting");
                }
            }

            if(_timeElapsed > MinLoadTime)
            {
                _asy.allowSceneActivation = true;
            }

            _timeElapsed += Time.deltaTime;
        }
    }

    [YarnCommand("LoadNextScene")]
    public void LoadNextScene()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        _asy = SceneManager.LoadSceneAsync(SceneToLoad);
        _asy.allowSceneActivation = false;
        _isLoading = true;

        while (!_asy.isDone)
        {
            yield return null;
        }
    }

    public void ChangeNextScene(string nextScene)
    {
        SceneToLoad = nextScene;
    }
}
