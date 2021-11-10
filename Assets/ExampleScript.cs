using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public enum Direction
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT
    }

    // If you make fields "public", you can edit the values of the component in Unity itself
    // The values you assign there will be stored in the game object/prefab itself
    // If you specify a value here in the code, it becomes the default value
    public string exampleStringField = "";

    // Works for floats and integers as well
    public float exampleNumberField = 0;

    // If you have an enum, it will show up as a drop-down in the inspector
    public Direction exampleEnumField = Direction.FRONT;

    // An array will show up as a list that you can expand indefinitely within the inspector, very useful!
    public string[] exampleArrayField;

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
        Debug.Log("Items in the list:");
        foreach (string item in exampleArrayField)
        {
            Debug.Log($"- {item}");
        }

        
        // This will call a method on the example script that was assigned
        // First we need to check whether it was really assigned though, like above
        if (exampleGameObjectField != null)
        {
            exampleScriptField.ChangeColor(Color.cyan);
        }

    }

    // This method changes the color of the material assigned to this game object
    public void ChangeColor(Color color)
    {
        // Normally we should do a null check, but here we'll assume that the MeshRenderer always exists
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void MoveRandom()
    {
        float amount = Random.Range(0f, 2f);
        switch (exampleEnumField)
        {
            case Direction.FRONT:   transform.position += amount * transform.forward;
                                    break;
            case Direction.BACK:   transform.position -= amount * transform.forward;
                                    break;
            case Direction.RIGHT:   transform.position += amount * transform.right;
                                    break;
            case Direction.LEFT:   transform.position -= amount * transform.right;
                                    break;
        }
    }

    // Update is called once per frame
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

        // If you press space, it will change the color to a random one as shown in the array below
        // It will also spawn a new game object in front of the current one
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Color[] colors = { Color.black, Color.green, Color.red, Color.yellow, Color.blue };
            ChangeColor(colors[Random.Range(0, colors.Length)]);

            // You can instantiate new game objects like this
            // This will spawn one of "exampleGameObjectField" one unit in front of the game object this component/script is on
            // That is, if it is actually assigned
            if (exampleGameObjectField != null)
            {
                var instance = Instantiate(exampleGameObjectField, this.transform.position + this.transform.forward, this.transform.rotation);
                // To preven the new one from also spawning stuff, we can set its "exampleGameObjectField" field to null, since as you saw above, we check for this
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
