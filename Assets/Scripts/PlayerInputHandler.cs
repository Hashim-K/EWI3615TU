using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerController pc;

    [SerializeField]
    private GameObject MeshObject;

    [SerializeField]
    private GameObject Prefab;

    private PlayerControls controls;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        MeshObject.transform.GetComponent<SkinnedMeshRenderer>().material = config.playerMaterial;
        config.Input.onActionTriggered += Input_onActionTriggered;
    }   

    private void Input_onActionTriggered(CallbackContext obj)
    {
        Debug.Log(obj.action.name);
        if (obj.action.name == "Horizontal")
        {
            Prefab.GetComponent<PlayerController>().Horizontal(obj);
        }
        if (obj.action.name == "Vertical")
        {
            Prefab.GetComponent<PlayerController>().Vertical(obj);
        }
        if (obj.action.name == "North")
        {
            Prefab.GetComponent<PlayerController>().West(obj);
        }
        if (obj.action.name == "East")
        {
            Prefab.GetComponent<Combat>().Kick(obj);
        }
        if (obj.action.name == "South")
        { 
            Prefab.GetComponent<Combat>().Punch(obj);
        }
        if (obj.action.name == "West")
        {
            Prefab.GetComponent<PlayerController>().West(obj);
        }
        if (obj.action.name == "RightStick")
        {
            Prefab.GetComponent<PlayerController>().RightStick(obj);
        }
        if (obj.action.name == "R1")
        {
            Prefab.GetComponent<PlayerController>().R1(obj);
        }
        if (obj.action.name == "R2")
        { 
            Prefab.GetComponent<Combat>().Block(obj);
        }
        if (obj.action.name == "R3")
        {
            Prefab.GetComponent<PlayerController>().R3(obj);
        }
        if (obj.action.name == "L1")
        {
            Prefab.GetComponent<PlayerController>().L1(obj);
        }
        if (obj.action.name == "L2")
        {
            Prefab.GetComponent<PlayerController>().L2(obj);
        }
        if (obj.action.name == "L3")
        {
            Prefab.GetComponent<PlayerController>().L3(obj);
        }
        if (obj.action.name == "Plus")
        {
            Prefab.GetComponent<PlayerController>().Plus(obj);
        }
        if (obj.action.name == "Minus")
        {
            Prefab.GetComponent<PlayerController>().Minus(obj);
        }
    }

}
