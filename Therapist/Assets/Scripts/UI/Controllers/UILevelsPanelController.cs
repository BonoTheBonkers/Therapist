using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelsPanelController : MonoBehaviour
{
    public GameObject targetPlaceBottom;
    public GameObject targetPlaceSelect;
    public GameObject targetPlaceHide;

    private RectTransform rectTransform;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetScale = Vector3.one * (MainManager.GetCurrentScreen() == EGameScreen.Levels ? 1.25f : 1.0f);
        Vector3 targetPosition = (MainManager.GetCurrentScreen() == EGameScreen.AttributeMenu || MainManager.GetCurrentScreen() == EGameScreen.MainMenu || MainManager.GetCurrentScreen() == EGameScreen.Board) ? targetPlaceBottom.transform.position : (MainManager.GetCurrentScreen() == EGameScreen.Levels ? targetPlaceSelect.transform.position : targetPlaceHide.transform.position);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, Time.deltaTime * 5.0f);
        GetRectTransform().localScale = Vector3.Lerp(GetRectTransform().localScale, targetScale, Time.deltaTime * 5.0f);
    }

    protected RectTransform GetRectTransform()
    {
        if(rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        return rectTransform;
    }
}
