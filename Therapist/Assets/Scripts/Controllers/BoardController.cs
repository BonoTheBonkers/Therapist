using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public FBoardConfig currentBoard;
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void InitializeCurrentBoard()
    {
        InitializeNewBoard(currentBoard);
    }

    public void InitializeNewBoard(FBoardConfig newBoard)
    {
        if(newBoard != currentBoard)
        {
            currentBoard = newBoard;
            EventManager.TriggerEvent("OnBoardChanged");
        }

        EventManager.TriggerEvent("OnInitializeBoard");
    }
}
