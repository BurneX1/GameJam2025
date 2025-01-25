using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public int maxFiles;
    public int actualFiles;
    int displayedFiles;
    public TextMeshProUGUI fileCounter;
    public CanvasManager canvasManager;

    public string winCanvasName;
    public string defeatCanvasName;

    public Door levelGoal;
    private void OnEnable()
    {


        actualFiles = 0;
        displayedFiles = 0;
        RefreshUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

        CheckVictory();

    }

    public void DefeatGame()
    {
        if (canvasManager == null) return;

        canvasManager.ActiveCanv(defeatCanvasName);
        canvasManager.gameObject.SetActive(false);
    }

    public void CheckVictory()
    {
        if (actualFiles <= maxFiles || canvasManager == null) return;

        canvasManager.ActiveCanv(winCanvasName);
        canvasManager.gameObject.SetActive(false);
    }



}
