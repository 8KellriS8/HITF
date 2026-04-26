using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSpecificGrab : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    [Header("Attach Points")]
    public Transform leftHandAttachTransform;
    public Transform rightHandAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftHandAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightHandAttachTransform;
        }
        base.OnSelectEntered(args);
    }
}
