using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTokenPlace : MonoBehaviour, IBoardInitializable
{
    protected ETokenPlaceType tokenPlaceType = ETokenPlaceType.None;
    protected List<TokenPlaceController> currentTokenPlaces = new List<TokenPlaceController>();
    protected BoardController boardController;
    void Start()
    {
    }
    public BoardController GetBoardController()
    {
        if (!boardController)
        {
            boardController = GetComponentInParent<BoardController>();
        }
        return boardController;
    }

    public void InitializeBoard(FBoardConfig inBoardConfig, Sequence inSequence)
    {
        for(int i = 0; i < currentTokenPlaces.Count; ++i)
        {
            if(currentTokenPlaces[i])
            {
                Destroy(currentTokenPlaces[i].gameObject);
            }
        }
        currentTokenPlaces.Clear();

        if (inBoardConfig == null || GetBoardController() == null)
        {
            return;
        }

        for (int i = 0; i < inBoardConfig.sequencesValues.Count; ++i)
        {
            if(tokenPlaceType == ETokenPlaceType.ExampleSequence || tokenPlaceType == ETokenPlaceType.CurrentSequence || (tokenPlaceType == ETokenPlaceType.CurrentTokens && !inBoardConfig.sequencesValues[i].IsSolvedOnStart))
            {
                TokenPlaceController newTokenPlace = Instantiate(PrefabsConfig.GetTokenPlacePrefab(), gameObject.transform).GetComponent<TokenPlaceController>();
                if (newTokenPlace != null)
                {
                    newTokenPlace.SetupTokenPlace(inBoardConfig.sequencesValues[i].value, tokenPlaceType);
                    currentTokenPlaces.Add(newTokenPlace);

                    if (!(tokenPlaceType == ETokenPlaceType.CurrentSequence && !inBoardConfig.sequencesValues[i].IsSolvedOnStart))
                    {
                        TokenController newToken = Instantiate(PrefabsConfig.GetTokenPrefab(), GetBoardController().gameObject.transform).GetComponent<TokenController>();
                        if (newToken != null)
                        {
                            if(tokenPlaceType == ETokenPlaceType.ExampleSequence && inBoardConfig.exampleConfig != EExampleConfig.SameSequence)
                            {
                                Sequence exampleSequence = null;
                                if(inBoardConfig.exampleConfig == EExampleConfig.SameAttribute)
                                {
                                    SequencesConfig.GetRandomSequence(MainManager.GetCurrentAttribute(), inBoardConfig, ref exampleSequence);
                                }
                                else
                                {
                                    SequencesConfig.GetRandomSequence(MainManager.GetCurrentAttribute(), inBoardConfig, ref exampleSequence);
                                }
                                if(exampleSequence)
                                {
                                    newToken.SetupToken(inBoardConfig.sequencesValues[i].value, exampleSequence.sprites[inBoardConfig.sequencesValues[i].value], newTokenPlace, tokenPlaceType);
                                }
                            }
                            else
                            {
                                newToken.SetupToken(inBoardConfig.sequencesValues[i].value, inSequence.sprites[inBoardConfig.sequencesValues[i].value], newTokenPlace, tokenPlaceType);
                            }
                            Vector3 newPosition = newToken.transform.position;
                            newPosition.y = 1000.0f;
                            newToken.transform.position = newPosition;
                            GetBoardController().RegisterToken(newToken);
                        }
                    }
                }

            }
        }

        AdjustTokenPlacesPositions();
    }

    protected void AdjustTokenPlacesPositions()
    {
        for(int i = 0; i < currentTokenPlaces.Count; ++i)
        {
            if(currentTokenPlaces[i] != null)
            {
                Vector3 newPosition = currentTokenPlaces[i].gameObject.transform.position;
                newPosition.x = (i * 170.0f * gameObject.transform.lossyScale.x) - ((currentTokenPlaces.Count - 1) * 85.0f * gameObject.transform.lossyScale.x) + gameObject.transform.position.x;
                currentTokenPlaces[i].gameObject.transform.position = newPosition;
            }
        }
    }
}
