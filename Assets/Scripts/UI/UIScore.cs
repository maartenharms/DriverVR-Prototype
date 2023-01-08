using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using TMPro;

public class UIScore : MonoBehaviour
{
    private TextMeshPro textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    private void Update()
    {
        textMesh.text = $"Score: {ScoreSystem.ScoreTotal}";
    }
}
