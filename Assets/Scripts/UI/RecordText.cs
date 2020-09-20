using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RecordText : MonoBehaviour
{
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = $"Your best distance is {Game.Record} m.";
    }
}
