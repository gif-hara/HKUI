using HK.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestSceneController : MonoBehaviour
{
    [SerializeField]
    private HKUIDocument documentPrefab;

    void Start()
    {
        var document = Instantiate(documentPrefab);
        document.Q<TMP_Text>("Header").text = "Hello, World!";
        var button = document.Q<Button>("Button");
        button.onClick.AddListener(() =>
        {
            Debug.Log("Button clicked");
        });
    }
}
