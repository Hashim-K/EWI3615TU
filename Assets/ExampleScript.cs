using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an example class, representing a Unity component. All Unity components should derive from MonoBehaviour, otherwise they will not be detected
/// as components. This allows Unity to send these classes special messages that trigger certain methods indicating game events, such as Start and Update.
/// 
/// Feel free to play around with this class, explore how it works, and how it responds to controls in-game!
/// Also feel free to edit the values of this component that is put on the ExamplePrefab in the Inspector (the side panel, when you select a game object)
/// </summary>
public class ExampleScript : MonoBehaviour
{
    public enum MovementType
    {
        Normal,
        Inverted,
        Static
    }

    // If you make fields "public", you can edit the values of the component in Unity itself
    // The values you assign there will be stored in the game object/prefab itself
    // If you specify a value here in the code, it becomes the default value
    public string exampleStringField = "";

    // Works for floats and integers as well
    public float exampleNumberField = 0;

    // Lets make an actual useful one
    public float movementSpeed;

    // If you have an enum, it will show up as a drop-down in the inspector
    public MovementType exampleEnumField = MovementType.Normal;

    // An array will show up as a list that you can expand indefinitely within the inspector, very useful!
    public Color[] exampleArrayField;

    // You can also have more complex types as inspector fields, such as prefabs and game objects (both fall under "GameObject")
    public GameObject exampleGameObjectField;

    // Finally, you can even have your own scripts as fields, either to restrict what you can put in such a field or for convenience (no need to call GetComponent<MyComponent>() then)
    public ExampleScript exampleScriptField;

    // There are many more fields you can create, with corresponding widgets in the inspector (e.g. Color)
    // Up to you to find them!

    private float timeCounter = 0;

    // Start is called before the first frame update, when all game objects are ready
    void Start()
    {
        // Use this method to log stuff to the console
        Debug.Log($"Example string: {exampleStringField}");
        Debug.Log($"Example number: {exampleNumberField}");
        
        // This will call a method on the example script that was assigned
        // First we need to check whether it was really assigned though, like above
        if (exampleGameObjectField != null)
        {
            exampleScriptField.Beep();
        }

    }

    // This method changes the color of the material assigned to this game object
    public void ChangeColor(Color color)
    {
        // Normally we should do a null check, but here we'll assume that the MeshRenderer always exists
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void Beep()
    {
        Debug.Log("Beep?");
    }

    public void MoveRandom()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        this.transform.position += new Vector3(x, y, z);
        Debug.Log($"Teleported cube {this.gameObject.name}");
    }

    // Update is called once per frame, this is where you want most dynamic things to happen in general
    // If we keep track of time (via deltaTime, the time between frames), we can actually make things happen once per second for instance
    // Lets use the exampleNumber field to determine the frequency!
    void Update()
    {
        // The counter will count until it reached the threshold, and then it will perform the random move and reset
        timeCounter += Time.deltaTime;
        if (timeCounter > exampleNumberField)
        {
            MoveRandom();
            timeCounter = 0;
        }

        // We can also listen for input here, and do stuff based on that

        // GetAxis returns a value between 1 and -1, indicating the amount of movement on that axis
        // By default, arrows up/down and W/A are bound to the "Horizontal" axis, arrows left/right and A/D to "Vertical"
        float leftRight = Input.GetAxis("Horizontal");
        float frontBack = Input.GetAxis("Vertical");

        // The multiplier will get its value based on that dropdown that we have in the inspector for the enum
        float multiplier;
        switch (exampleEnumField)
        {
            case MovementType.Normal:       multiplier = 1f;
                                            break;
            case MovementType.Inverted:     multiplier = -1f;
                                            break;
            // Also covers the MovementType.Static case
            default:                        multiplier = 0f;
                                            break;
        }

        // transform.right and transform.forward are unit vectors pointing in the respective directions of the object
        // If you would rotate the object, using these vectors for changing the position will ensure that movement is done relative to this rotation
        // You can look at it as the object's own little coordinate system, expressed in world space
        // Notice that we also multiply by Time.deltaTime, this makes the amount of movement frame-rate independent.
        this.transform.position += 
            movementSpeed * Time.deltaTime * multiplier * leftRight * this.transform.right +
            movementSpeed * Time.deltaTime * multiplier * frontBack * this.transform.forward;

        // Lets use the mouse buttons to rotate the cube
        if (Input.GetMouseButton(0))
        {
            // The vector is interpreted as: Around x, around y, around z
            // Again notice how we multiply by deltaTime here
            this.transform.Rotate(Time.deltaTime * new Vector3(0, movementSpeed * -10, 0));
        }
        if (Input.GetMouseButton(1))
        {
            this.transform.Rotate(Time.deltaTime * new Vector3(0, movementSpeed * 10, 0));
        }

        // If you press SPACE, it will change the color to a random one in the arrayField that we have at the top
        // It will also spawn a new game object in front of the current one
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // First we check whether the array actually contains anything, otherwise there's nothing to choose from and we would get an Exception
            if (exampleArrayField.Length > 0)
            {
                ChangeColor(exampleArrayField[Random.Range(0, exampleArrayField.Length)]);
            }

            // You can instantiate new game objects like this
            // This will spawn one of "exampleGameObjectField" one unit in front of the game object this component/script is on
            // That is, if it is actually assigned
            if (exampleGameObjectField != null)
            {
                var instance = Instantiate(exampleGameObjectField, this.transform.position + this.transform.forward, this.transform.rotation);
                // To prevent the new one from also spawning stuff, we can set its "exampleGameObjectField" field to null, since as you saw above, we check for this
                // This is of course assuming that the assigned prefab to spawn has this script/component (in our case it does, this is just to show that it doesn't need to be that way), so we need to do a null check first
                var exampleScriptComponent = instance.GetComponent<ExampleScript>();
                if (exampleScriptComponent != null)
                {
                    exampleScriptComponent.exampleGameObjectField = null;
                }
            }
        }
    }
}
