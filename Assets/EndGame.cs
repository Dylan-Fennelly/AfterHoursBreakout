using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image endImage;
    [SerializeField]
    private TextMeshPro TextMeshPro;
    [SerializeField]
    private UnityEngine.UI.Button button;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endImage.gameObject.SetActive(true);
            TextMeshPro.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }
}
