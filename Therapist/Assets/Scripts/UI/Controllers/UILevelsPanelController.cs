using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelsPanelController : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        targetPosition.y = MainManager.GetCurrentScreen() == EGameScreen.AttributeMenu || MainManager.GetCurrentScreen() == EGameScreen.MainMenu ? 0.0f : -150.0f;
        gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(gameObject.GetComponent<RectTransform>().anchoredPosition, targetPosition, Time.deltaTime * 5.0f);
    }
}
