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
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.OnTargetTokenPlaceChanged, OnTargetTokenPlaceChanged);
    }

    void OnDisable()
    {
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
