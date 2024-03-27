using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiddenObjectCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hiddenObjectCounterLabel;

    private List<Transform> _foundObjectsList = new List<Transform>();

    private void Start()
    {
        ReactToPointer.Instance.OnObjectClicked += Pointer_OnObjectClicked;
        UpdateText();
    }

    private void Pointer_OnObjectClicked(object sender, Transform e)
    {
        if (_foundObjectsList.Contains(e))
            return;
        _foundObjectsList.Add(e);
        UpdateText();
    }

    private void UpdateText()
    {
        hiddenObjectCounterLabel.SetText($"{_foundObjectsList.Count}/9");
    }
}
