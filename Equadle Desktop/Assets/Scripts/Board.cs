using System.Diagnostics;
using System.Security.AccessControl;
using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    private static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[] {
        KeyCode.X, KeyCode.Equals, KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4,
        KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Minus, KeyCode.Slash,
        KeyCode.KeypadPlus, KeyCode.KeypadMultiply, KeyCode.KeypadDivide, KeyCode.KeypadMinus, KeyCode.Keypad0,
        KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6,
        KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9,
    };

    private Row[] rows;

    private string[] solutions;
    private string[] validWords;
    private string word;

    private int rowIndex;
    private int columnIndex;

    [Header("States")] //just for info on the front
    public Tile.State emptyState;
    public Tile.State occupiedState;
    public Tile.State correctState;
    public Tile.State wrongSpotState;
    public Tile.State incorrectState;

    [Header("UI")]
    public TextMeshProUGUI invalidWordText;
    public TextMeshProUGUI equals1p;
    public TextMeshProUGUI equals1m;
    public TextMeshProUGUI equals2p;
    public TextMeshProUGUI equals2m;
    public TextMeshProUGUI infoDescription;
    public Button newWordButton;
    public Button tryAgainButton;
    public Button infoOpen;
    public Button infoClose;
    public GameObject infoBox;


    private void Awake()
    {
        rows = GetComponentsInChildren<Row>();
    }

    private void Start()
    {
        LoadData();
        NewGame();
        
        infoOpen.gameObject.SetActive(true);
    }

    public void NewGame()
    {
        ClearBoard();
        SetRandomWord();

        enabled = true;
    }

    public void TryAgain()
    {
        ClearBoard();

        enabled = true;
    }

    private void LoadData()
    {
        TextAsset textFile = Resources.Load("fraction_valid") as TextAsset;
        validWords = textFile.text.Split('\n');

        textFile = Resources.Load("fraction_accepted") as TextAsset;
        solutions = textFile.text.Split('\n');
    }

    private void SetRandomWord()
    {
        int index = UnityEngine.Random.Range(0, solutions.Length);
        word = solutions[index];
        word = word.ToLower().Trim();

        DisableAllX();

        if (index < 20)
        {
            equals1p.gameObject.SetActive(true);
        }
        else if (index > 19 && index < 49)
        {
            equals1m.gameObject.SetActive(true);
        }
        else if (index > 48 && index < 78)
        {
            equals2p.gameObject.SetActive(true);
        }
        else if (index > 77 && index < 98)
        {
            equals2m.gameObject.SetActive(true);
        }
    }

    private void Update()
    {

        Row currentRow = rows[rowIndex];

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            columnIndex = Mathf.Max(columnIndex -1, 0); // ele pega o maior entre 0 e -1, pra que nunca fique out of bounds
            currentRow.tiles[columnIndex].SetLetter('\0');
            currentRow.tiles[columnIndex].SetState(emptyState);

            invalidWordText.gameObject.SetActive(false);
        }
        else if (columnIndex >= currentRow.tiles.Length)
        {
            // submit a row
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SubmitRow(currentRow);
            }
        }
        else
        {
            for (int i = 0; i < SUPPORTED_KEYS.Length; i++)
            {
                if (Input.GetKeyDown(SUPPORTED_KEYS[i]))
                {
                    if (i == 14)
                    {
                        //plus sign
                        char actualSign = '+';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 15)
                    {
                        //multiply sign
                        char actualSign = '*';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 16)
                    {
                        //multiply sign
                        char actualSign = '/';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 17)
                    {
                        //multiply sign
                        char actualSign = '-';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 18)
                    {
                        //multiply sign
                        char actualSign = '0';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 19)
                    {
                        //multiply sign
                        char actualSign = '1';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 20)
                    {
                        //multiply sign
                        char actualSign = '2';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 21)
                    {
                        //multiply sign
                        char actualSign = '3';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 22)
                    {
                        //multiply sign
                        char actualSign = '4';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 23)
                    {
                        //multiply sign
                        char actualSign = '5';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 24)
                    {
                        //multiply sign
                        char actualSign = '6';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 25)
                    {
                        //multiply sign
                        char actualSign = '7';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 26)
                    {
                        //multiply sign
                        char actualSign = '8';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else if (i == 27)
                    {
                        //multiply sign
                        char actualSign = '9';
                        currentRow.tiles[columnIndex].SetLetter((char)actualSign);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                    else
                    {
                        currentRow.tiles[columnIndex].SetLetter((char)SUPPORTED_KEYS[i]);
                        currentRow.tiles[columnIndex].SetState(occupiedState);
                        columnIndex++;
                        break;
                    }
                }
            }
        }
    }

    private void SubmitRow(Row row)
    {
        if (!IsValidWord(row.word))
        {
            invalidWordText.gameObject.SetActive(true);
            return;
        }

        string remaining = word;

        for (int i = 0; i < row.tiles.Length; i++)
        {
            Tile tile = row.tiles[i];

            if (tile.letter == word[i])
            {
                //correct
                tile.SetState(correctState);

                //função remove (int com a posição da letra pra retirar, números de letras pra retirar depois da posição)
                remaining = remaining.Remove(i, 1);
                //subtituição do que era uma letra para um espaço vazio, para não mudar o tamanho da string
                remaining = remaining.Insert(i, " ");
            }
            else if (!word.Contains(tile.letter))
            {
                //incorrect
                tile.SetState(incorrectState);
            }
        }

        for (int i = 0; i < row.tiles.Length; i++)
        {
            Tile tile = row.tiles[i];

            if (tile.state != correctState && tile.state != incorrectState)
            {
                //wrong spot
                if (remaining.Contains(tile.letter))
                {
                    tile.SetState(wrongSpotState);

                    int index = remaining.IndexOf(tile.letter);
                    remaining = remaining.Remove(index, 1);
                    remaining = remaining.Insert(index, " ");
                }
                else
                {
                    tile.SetState(incorrectState);
                }
            }
        }

        if (HasWon(row))
        {
            enabled = false;
        }

        rowIndex++;
        columnIndex = 0;

        if (rowIndex >= rows.Length)
        {
            // lost the game
            enabled = false;
        }
    }

    private void ClearBoard()
    {
        for (int row = 0; row < rows.Length; row++)
        {
            for (int col = 0; col < rows[row].tiles.Length; col++)
            {
                rows[row].tiles[col].SetLetter('\0');
                rows[row].tiles[col].SetState(emptyState);
            }
        }

        rowIndex = 0;
        columnIndex = 0;
    }

    private bool IsValidWord(string word)
    {
        for (int i = 0; i < validWords.Length; i++)
        {            
            string wordValid = validWords[i];
            int count = 0;

            for (int j = 0; j < 6; j++)
            {
                if (wordValid[j] == word[j])
                {
                    count++;
                }
            }

            if (count == 6)
            {
                return true;
            }

            //if (validWords[i] == word)
            //{
            //    return true;
            //}
        }

        return false;
    }

    private bool HasWon(Row row)
    {
        for (int i = 0; i < row.tiles.Length; i++)
        {
            if (row.tiles[i].state != correctState)
            {
                return false;
            }
        }

        return true;
    }

    private void OnEnable()
    {
        tryAgainButton.gameObject.SetActive(false);
        newWordButton.gameObject.SetActive(false);
    }

    /// This function is called when the behaviour becomes disabled or inactive.
    private void OnDisable()
    {
        tryAgainButton.gameObject.SetActive(true);
        newWordButton.gameObject.SetActive(true);
    }

    public void InfoOpen()
    {
        //infoDescription.gameObject.SetActive(true);
        infoBox.gameObject.SetActive(true);
        infoClose.gameObject.SetActive(true);
        infoOpen.gameObject.SetActive(false);
    }

    public void InfoClose()
    {
        //infoDescription.gameObject.SetActive(false);
        infoBox.gameObject.SetActive(false);
        infoClose.gameObject.SetActive(false);
        infoOpen.gameObject.SetActive(true);
    }

    private void DisableAllX()
    {
        equals1p.gameObject.SetActive(false);
        equals1m.gameObject.SetActive(false);
        equals2p.gameObject.SetActive(false);
        equals2m.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
