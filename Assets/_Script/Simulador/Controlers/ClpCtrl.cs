using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static SimulationManager;

public class ClpCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;
    private ParameterObj _parameterObj;

    [SerializeField] private GameObject _clpScreen;
    private GameState _gameState;

    [Header("--- Display ---")]
    [SerializeField] private int[] _charValue; //The int to each character in the display
    [SerializeField] private TMP_Text[] _displayChar; //The UI Object of each character in the display
    [SerializeField] private int _selectedDecimal; //The selected character we are working in

    [Header("--- Parameter ---")]
    [SerializeField] private TMP_Text _displayP; //THE DISPLAY "P" ON THE DISPLAY
    [SerializeField] private string _paramKey; //THE DISPLAY STRING USED TO SEARCH THE ASSIGNED VALUE
    [SerializeField] private int[] _paramValue; // THE VALUE OF EACH PARAM
    [SerializeField] private bool _isParOpen = false;

    // Game State subscription 
    private void Awake() { SimulationManager.OnStateChanged += OnStateChanged; }

    private void OnDestroy() { SimulationManager.OnStateChanged -= OnStateChanged; }

    public void OnStateChanged(GameState state)
    {
        if (state == GameState.WirePlacement)
            _gameState = state;
        else
            _gameState = state;

    }

    void Start()
    {
        _inputCtrl = InputCtrl.Instance;
        _parameterObj = ParameterObj.Instance;

        _clpScreen.SetActive(false);

        _displayP.text = "P";
        _selectedDecimal = 3;

        BlinkingChar();
    }

    void Update()
    {
        if(_gameState == GameState.ParameterPhase)
        {
            if (_inputCtrl.click && _inputCtrl.currentObject == this.gameObject)
                _clpScreen.SetActive(true);
        }

        _displayChar[0].text = _charValue[0].ToString();
        _displayChar[1].text = _charValue[1].ToString();
        _displayChar[2].text = _charValue[2].ToString();
        _displayChar[3].text = _charValue[3].ToString();

        //Update the parameter panel
        _parameterObj.UpdateParamPanel();

    }

    public void IncrementChar()
    {
        //Increment value of the selected decimal char
        if(_charValue[_selectedDecimal] == 9)
            _charValue[_selectedDecimal] = 0;
        else
            _charValue[_selectedDecimal]++;
    }

    public void DecrementChar()
    {
        //Decrement value of the selected decimal char
        if (_charValue[_selectedDecimal] == 0)
            _charValue[_selectedDecimal] = 9;
        else
            _charValue[_selectedDecimal]--;
    }

    public void SelectLeft()
    {
        //Make sure the character isn't transparent
        _displayChar[_selectedDecimal].color = new Color(255f, 0f, 0f, 255f);

        //Select the next character
        if (_selectedDecimal == 0)
            _selectedDecimal = 3;
        else
            _selectedDecimal--;
    }

    public void SetParameters()
    {
        //Make sure the character isn't transparent
        _displayChar[_selectedDecimal].color = new Color(255f, 0f, 0f, 255f);

        //Open the parameter display
        if (_isParOpen == false)
        {
            //Prepare the display
            _isParOpen = true;
            _displayP.text = " ";
            _selectedDecimal = 3;

            _paramKey = _charValue[0].ToString() + _charValue[1].ToString() + _charValue[2].ToString() + _charValue[3].ToString();

            //Clean the display string
            for (int i = 0; i < _charValue.Length; i++)
            {
                _charValue[i] = 0;
                _displayChar[i].text = "";
            }

            // Fetch parameter
            _paramValue = _parameterObj.SearchParamValue(_paramKey);

            if( _paramValue == null)
            {
                _displayChar[0].text = "E";
                _displayChar[1].text = "R";
                _displayChar[2].text = "R";
                _displayChar[3].text = "O";

            }
            else
            {
                //Display assign each 
                for (int i = 3; i >= 0; i--)
                {
                    _charValue[i] = _paramValue[i];
                    _displayChar[i].text = _paramValue[i].ToString();
                }
            }


        }
        else
        {
            //Prepare the display
            _isParOpen = false;
            _displayP.text = "P";
            _selectedDecimal = 3;

            //SET THE ASSINGED PARAMETER VALUE
            _parameterObj.SetParam(_paramKey, _charValue);

            _paramValue = null;

            // CLEAN THE DISPLAY
            for (int i = 0; i < _charValue.Length; i++)
            {
                _charValue[i] = 0;
                _displayChar[i].text = "0";
            }

        }
    }

    async void BlinkingChar()
    {
        //Blink the character alpha every 0.25s
        if (_displayChar[_selectedDecimal].color.a == 255)
            _displayChar[_selectedDecimal].color = new Color(255f, 0f, 0f, 0f);
        else
            _displayChar[_selectedDecimal].color = new Color(255f, 0f, 0f, 255f);

        await Task.Delay(250);

        BlinkingChar();
    }

    public void ClosePanel()
    {
        //CLOSE THE PARAMETER DISPLAY 
        _isParOpen = false;
        _displayP.text = "P";
        _selectedDecimal = 3;

        // --- CLEAN THE DISPLAY
        for (int i = 0; i < _charValue.Length; i++)
        {
            _charValue[i] = 0;
            _displayChar[i].text = "0";
        }

        _clpScreen.SetActive(false);
    }
}
