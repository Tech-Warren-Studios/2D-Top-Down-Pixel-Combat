using UnityEngine;

public class InitialTransparentObjectActivator : MonoBehaviour
{
    [SerializeField]
    private TransparentDetection targetObject; // Assign the object you want to make transparent in the inspector

    void Start()
    {
        // Invoke the transparency effect for the assigned object when the game starts
        if (targetObject != null)
        {
            targetObject.ForceTransparency();
        }
    }
}

