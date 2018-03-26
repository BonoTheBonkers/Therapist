using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayersController : UIController
{
    protected List<GameObject> playersGameObjects = new List<GameObject>();

	public override void OnEnable ()
    {
        base.OnEnable();
        RedrawPlayersList();
        EventManager.StartListening(EventManager.OnPlayersListChanged, RedrawPlayersList);
	}

    public override void OnDisable ()
    {
        base.OnDisable();
        RemovePlayersList();
        EventManager.StopListening(EventManager.OnPlayersListChanged, RedrawPlayersList);
    }

    void RemovePlayersList()
    {
        foreach (GameObject current in playersGameObjects)
        {
            Destroy(current);
        }
    }

    void RedrawPlayersList()
    {
        RemovePlayersList();

        if(MainManager.GetCurrentUser().players.Count == 0)
        {
            UIManager.SetNewPlayerScreenActive(true);
            UIManager.SetPlayersListActive(false);
        }
        else
        {
            for (int i = 0; i < MainManager.GetCurrentUser().players.Count; ++i)
            {
                GameObject current = Instantiate<GameObject>(PrefabsConfig.GetPlayerAtListPrefab(), gameObject.transform);
                RectTransform rectTransform = current.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, i * 150.0f - ((MainManager.GetCurrentUser().players.Count - 1) * 75.0f));
                current.GetComponent<UIButtonUserSelect>().InitializePlayerButton(MainManager.GetCurrentUser().players[i]);
                playersGameObjects.Add(current);
            }
        }
    }
}
