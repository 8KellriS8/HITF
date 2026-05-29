using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSpecificGrab : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    [Header("Attach Points")]
    public Transform leftHandAttachTransform;
    public Transform rightHandAttachTransform;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    // ИСПОЛЬЗУЕМ OnSelectEntering (вызывается ДО фиксации захвата)
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        // Проверяем тег у интектора (руки)
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            if (leftHandAttachTransform != null)
            {
                attachTransform = leftHandAttachTransform;
            }
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            if (rightHandAttachTransform != null)
            {
                attachTransform = rightHandAttachTransform;
            }
        }

        // Обязательно вызываем базовый метод ПОСЛЕ смены attachTransform
        base.OnSelectEntering(args);
        audioSource1.Play();
    }
}