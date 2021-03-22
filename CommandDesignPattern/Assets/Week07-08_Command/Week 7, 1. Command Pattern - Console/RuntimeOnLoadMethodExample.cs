using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RuntimeOnLoadMethodExample
{

    /*Methods marked [RuntimeInitializeOnLoadMethod] 
    * are invoked after the game has been loaded. 
    * This is after the Awake method has been invoked.
    * 
    * This lets us run these static methods once 
    * without having to attach this script 
    * to a GameObject in the scene.
    * 
    * For more on this, see: 
    * https://docs.unity3d.com/ScriptReference/RuntimeInitializeOnLoadMethodAttribute.html?_ga=2.158786490.1200226918.1582498394-999459734.1576303504 
    */

        /*
    [RuntimeInitializeOnLoadMethod]
    static void MyOnLoadMethod()
    {
        Debug.Log("This method will run after the Awake method " +
                  "even though this script/class does not extend MonoBehaviour");

    }
    */
}