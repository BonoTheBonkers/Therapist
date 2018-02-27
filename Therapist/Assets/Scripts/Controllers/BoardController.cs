using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : SingletonManager<BoardController>, IBoardInitializable
{
    public FBoardConfig currentBoard;
    public Sequence currentSequence;

    protected ExampleSequenceController exampleSequenceController;
    protected CurrentSequenceController currentSequenceController;
    protected CurrentTokensController currentTokensController;

    protected List<TokenController> tokenControllers = new List<TokenController>();

    void Start()
    {
        exampleSequenceController = GetComponentInChildren<ExampleSequenceController>();
        currentSequenceController = GetComponentInChildren<CurrentSequenceController>();
        currentTokensController = GetComponentInChildren<CurrentTokensController>();
    }

    public void InitializeCurrentBoard()
    {
        InitializeBoard(currentBoard, currentSequence);
    }

    public static void InitializeBoardPublic(FBoardConfig inBoardConfig, Sequence inSequence)
    {
        if(Instance)
        {
            Instance.InitializeBoard(inBoardConfig, inSequence);
        }
    }

    public void InitializeBoard(FBoardConfig inBoardConfig, Sequence inSequence)
    {
        for (int i = 0; i < tokenControllers.Count; ++i)
        {
            if (tokenControllers[i])
            {
                Destroy(tokenControllers[i].gameObject);
            }
        }
        tokenControllers.Clear();

        if (inBoardConfig != currentBoard)
        {
            currentBoard = inBoardConfig;
            EventManager.TriggerEvent("OnBoardChanged");
        }
        if (inSequence != currentSequence)
        {
            currentSequence = inSequence;
            EventManager.TriggerEvent("OnSequenceChanged");
        }

        if(exampleSequenceController != null)
        {
            exampleSequenceController.InitializeBoard(inBoardConfig, inSequence);
        }
        if (currentSequenceController != null)
        {
            currentSequenceController.InitializeBoard(inBoardConfig, inSequence);
        }
        if (currentTokensController != null)
        {
            currentTokensController.InitializeBoard(inBoardConfig, inSequence);
        }
        
        EventManager.TriggerEvent("OnInitializeBoard");
    }

    public void RegisterToken(TokenController newToken)
    {
        tokenControllers.Add(newToken);
    }
}
