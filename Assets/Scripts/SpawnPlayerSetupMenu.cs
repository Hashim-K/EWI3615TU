using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject playerSetupMenuPrefab;

    private GameObject rootMenu;
    public PlayerInput input;

    private void Awake()
    {
        rootMenu = GameObject.Find("MainLayout");
        if(rootMenu != null)
        {
            var menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);
            //menu.transform.Translate(new Vector3(400 * (float)System.Math.Pow(-1,input.playerIndex + 1), 0, 0));
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<PlayerSetupMenuController>().setPlayerIndex(input.playerIndex);
        }
        
    }
}
