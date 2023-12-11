using System.Security.AccessControl;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [System.Serializable]
    public class State
    {
        public UnityEngine.Color fillColor;
        public UnityEngine.Color outlineColor;
    }

    public State state { get; private set; }
    public char letter { get; private set; }

    private TextMeshProUGUI text;
    private Image fill;
    private Outline outline;


    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        fill = GetComponent<Image>();
        outline = GetComponent<Outline>();
    }

    public void SetLetter(char letter)
    {
        //show the letter in tile
        this.letter = letter;
        text.text = letter.ToString();
    }

    public void SetState(State state)
    {
        // set color based on state
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;
    }
}
