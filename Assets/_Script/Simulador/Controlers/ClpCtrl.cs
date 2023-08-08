using System;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static ParameterObj;
using static SimulationManager;

public class ClpCtrl : MonoBehaviour
{
    private InputCtrl _inputCtrl;
    private ParameterObj _parameterObj;

    [SerializeField] private GameObject _clpScreen;
    private GameState _gameState;

    [Header("--- Display ---")]
    [SerializeField] private int[] _decimals; //EACH CHARACTER VALUE FROM THE DISPLAY
    [SerializeField] private int _selectedDecimal; 
    [SerializeField] private TMP_Text[] _displayChar;

    [Header("--- Parameter ---")]
    [SerializeField] private TMP_Text _displayP; //THE DISPLAY "P" ON THE DISPLAY
    [SerializeField] private string _key; //THE DISPLAY STRING USED TO SEARCH THE ASSIGNED VALUE
    [SerializeField] private int[] _param; // THE VALUE OF EACH PARAM
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

        _displayChar[0].text = _decimals[0].ToString();
        _displayChar[1].text = _decimals[1].ToString();
        _displayChar[2].text = _decimals[2].ToString();
        _displayChar[3].text = _decimals[3].ToString();
    }

    public void AddInt()
    {
        if(_decimals[_selectedDecimal] == 9)
            _decimals[_selectedDecimal] = 0;
        else
            _decimals[_selectedDecimal]++;
    }

    public void DecreaseInt()
    {
        if (_decimals[_selectedDecimal] == 0)
            _decimals[_selectedDecimal] = 9;
        else
            _decimals[_selectedDecimal]--;
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

    public void Parameter()
    {
        //Make sure the character isn't transparent
        _displayChar[_selectedDecimal].color = new Color(255f, 0f, 0f, 255f);

        //Open the parameter display
        if (_isParOpen == false)
        {
            _isParOpen = true;
            _displayP.text = " ";
            _selectedDecimal = 3;
            _key = _decimals[0].ToString() + _decimals[1].ToString() + _decimals[2].ToString() + _decimals[3].ToString();

            // CLEAN DISPLAY
            for (int i = 0; i < _decimals.Length; i++)
            {
                _decimals[i] = 0;
                _displayChar[i].text = "";
            }

            // Fetch parameter
            _param = _parameterObj.SearchParam(_key);

            if(_param != null)
            {
                for (int i = 3; i >= 0; i--)
                {
                    _decimals[i] = _param[i];
                    _displayChar[i].text = _param[i].ToString();
                }
            }
            

        }
        else
        {
            //CLOSE THE PARAMETER DISPLAY 
            _isParOpen = false;
            _displayP.text = "P";
            _selectedDecimal = 3;

            //SET THE ASSINGED PARAMETER VALUE
            if(_param == null)
            {
                _parameterObj.SetParam(_key, _decimals);
            }
            else
            {
                if (_decimals.SequenceEqual(_param) == false)
                    _parameterObj.SetParam(_key, _decimals);
            }

            _param = null;

            // --- CLEAN THE DISPLAY
            for (int i = 0; i < _decimals.Length; i++)
            {
                _decimals[i] = 0;
                _displayChar[i].text = "0";
            }
        }
    }

    async void BlinkingChar()
    {
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
        for (int i = 0; i < _decimals.Length; i++)
        {
            _decimals[i] = 0;
            _displayChar[i].text = "0";
        }

        _clpScreen.SetActive(false);
    }
}
