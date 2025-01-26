using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class LevelManager : MonoBehaviour
{
    public int maxFiles;
    public int actualFiles;
    int displayedFiles;

    public string postDefeatCanvas;
    public string postWinCanvas;

    public TextMeshProUGUI fileCounter;
    public CanvasManager canvasManager;

    public string winCanvasName;
    public string defeatCanvasName;

    public Door levelGoal;
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        actualFiles = 0;
        displayedFiles = -1;
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshUI()
    {
        if (displayedFiles == actualFiles || fileCounter==null) return;
        displayedFiles = actualFiles;
        fileCounter.text = displayedFiles + " / " + maxFiles;

    }

    public void AddFile()
    {
        if(actualFiles<maxFiles) actualFiles++;

        RefreshUI();

        CheckDoorLock();

    }

    public void DefeatGame()
    {
        if (canvasManager == null) return;

        canvasManager.ActiveCanv(defeatCanvasName);
        canvasManager.gameObject.SetActive(false);
        StartCoroutine(WaitTime(5, () => { GameManager.manager.Change(postDefeatCanvas); }));
    }

    public void CheckDoorLock()
    {
        if (actualFiles < maxFiles) return;

        levelGoal.OpenDoor();
    }

    public void CheckVictory()
    {
        if (canvasManager == null) return;

        canvasManager.ActiveCanv(winCanvasName);
        canvasManager.gameObject.SetActive(false);

        StartCoroutine(WaitTime(3, () => { GameManager.manager.Change(postWinCanvas); }));
    }

    public IEnumerator WaitTime(float time,Action callback)
    {
        yield return new WaitForSecondsRealtime(time);

        callback.Invoke();
    }


}
