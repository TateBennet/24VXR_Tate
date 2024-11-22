using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class Invisiline : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    private XRInteractorLineVisual lineVisual;

    private void Awake()
    {
        // Get the components
        rayInteractor = GetComponent<XRRayInteractor>();
        lineVisual = GetComponent<XRInteractorLineVisual>();

        // Optionally disable the line visual at the start
        if (lineVisual != null)
        {
            lineVisual.enabled = false;
        }
    }

    private void OnEnable()
    {
        // Subscribe to hover events
        rayInteractor.hoverEntered.AddListener(OnHoverEntered);
        rayInteractor.hoverExited.AddListener(OnHoverExited);
        rayInteractor.uiHoverEntered.AddListener(OnUIEntered);
        rayInteractor.uiHoverExited.AddListener(OnUIExited);
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        rayInteractor.hoverEntered.RemoveListener(OnHoverEntered);
        rayInteractor.hoverExited.RemoveListener(OnHoverExited);
        rayInteractor.uiHoverEntered.RemoveListener(OnUIEntered);
        rayInteractor.uiHoverExited.RemoveListener(OnUIExited);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Enable the line visual when pointing at a grabbable object
        if (lineVisual != null)
        {
            lineVisual.enabled = true;
        }
    }

    private void OnUIEntered(UIHoverEventArgs args)
    {
        // Enable the line visual when pointing at a grabbable object
        if (lineVisual != null)
        {
            lineVisual.enabled = true;
        }
    }

    private void OnUIExited(UIHoverEventArgs args)
    {
        // Disable the line visual when no longer pointing at a grabbable object
        if (lineVisual != null)
        {
            lineVisual.enabled = false;
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        // Disable the line visual when no longer pointing at a grabbable object
        if (lineVisual != null)
        {
            lineVisual.enabled = false;
        }
    }
}