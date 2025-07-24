using System;
using Objects;
using UnityEngine;
using UnityEngine.Events;

public class L2S3PlacementChecker : MonoBehaviour
{
    [SerializeField] private BulbPlace[] places;
    [SerializeField] private BulbPlace[] correctPlaces;
    [SerializeField] private UnityEvent onCorrectPlacement;
    [SerializeField] private UnityEvent onWrongPlacement;

    private void Awake()
    {
        foreach (var place in places)
        {
            place.ChangedBulb += CheckPlacement;
        }
    }

    private void OnDestroy()
    {
        foreach (var place in places)
        {
            place.ChangedBulb -= CheckPlacement;
        }
    }

    private void CheckPlacement(bool _)
    {
        var filledPlaces = 0;
        foreach (var place in places)
        {
            if (place.HasBulb)
            {
                filledPlaces++;
            }
        }

        if (filledPlaces < correctPlaces.Length)
        {
            // Placement is not complete, yet
            return;
        }

        foreach (var place in correctPlaces)
        {
            if (!place.HasBulb)
            {
                onWrongPlacement.Invoke();
                return;
            }
        }
        
        onCorrectPlacement.Invoke();
    }
}
