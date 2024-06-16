using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _score.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _score.Changed -= OnChanged;
    }

    public void OnChanged(int amount)
    {
        _textMeshPro.text = amount.ToString();
    }
}
