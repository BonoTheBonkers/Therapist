using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : UIController, IBoardInitializable
{
    public FBoardConfig currentBoard;
    [HideInInspector]
    public Sequence currentSequence;
    public GameObject tokensParent;
    public GameObject draggedParent;

    protected ExampleSequenceController exampleSequenceController;
    protected CurrentSequenceController currentSequenceController;
    protected CurrentTokensController currentTokensController;

    protected List<TokenController> tokenControllers = new List<TokenController>();

    public override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartListening(EventManager.OnTargetTokenPlaceChanged, OnTargetTokenPlaceChanged);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventManager.StopListening(EventManager.OnTargetTokenPlaceChanged, OnTargetTokenPlaceChanged);
    }

    public void OnTargetTokenPlaceChanged()
    {
        foreach(TokenController current in tokenControllers)
        {
            if(current != null && !current.IsTokenInFinalPlace())
            {
                return;
            }
        }

        EventManager.TriggerEvent(EventManager.OnCorrectAnswer);
    }

    public ExampleSequenceController GetExampleSequenceController()
    {
        if (!exampleSequenceController)
        {
            exampleSequenceController = GetComponentInChildren<ExampleSequenceController>();
        }
        return exampleSequenceController;
    }

    public CurrentSequenceController GetCurrentSequenceController()
    {
        if (!currentSequenceController)
        {
            currentSequenceController = GetComponentInChildren<CurrentSequenceController>();
        }
        return currentSequenceController;
    }

    public CurrentTokensController GetCurrentTokensController()
    {
        if (!currentTokensController)
        {
            currentTokensController = GetComponentInChildren<CurrentTokensController>();
        }
        return currentTokensController;
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
            EventManager.TriggerEvent(EventManager.OnBoardChanged);
        }
        if (inSequence != currentSequence)
        {
            currentSequence = inSequence;
            EventManager.TriggerEvent(EventManager.OnSequenceChanged);
        }

        if (GetExampleSequenceController() != null)
        {
            GetExampleSequenceController().InitializeBoard(inBoardConfig, inSequence);
        }
        if (GetCurrentSequenceController() != null)
        {
            GetCurrentSequenceController().InitializeBoard(inBoardConfig, inSequence);
        }
        if (GetCurrentTokensController() != null)
        {
            GetCurrentTokensController().InitializeBoard(inBoardConfig, inSequence);
        }
        
        EventManager.TriggerEvent(EventManager.OnInitializeBoard);
    }

    public void RegisterToken(TokenController newToken)
    {
        tokenControllers.Add(newToken);
    }
}
