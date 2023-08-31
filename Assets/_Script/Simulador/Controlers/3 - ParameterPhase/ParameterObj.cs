using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParameterObj : MonoBehaviour
{
    public static ParameterObj Instance;
    public List<Parameter> parameterList;
    public List<string> paramKeys;

    [SerializeField] private TMP_Text _paramPanel;

    public class Parameter 
    { 
        public string key; 
        public int[] value = new int[4]; 

        public Parameter(string key, int v0, int v1, int v2, int v3)
        {
            this.key = key;
            this.value[0] = v0;
            this.value[1] = v1;
            this.value[2] = v2;
            this.value[3] = v3;
        }

    }

    private void Awake() => Instance = this;

    private void Start()
    {
        parameterList = new List<Parameter>();

        paramKeys = new List<string>();

        // INICIO:
        paramKeys.Add("0000");
        paramKeys.Add("0204");

        // MODO POSICIONADOR
        paramKeys.Add("0385");
        paramKeys.Add("0202");
        paramKeys.Add("1070");
        paramKeys.Add("1081");
        paramKeys.Add("1101");
        paramKeys.Add("1102");

        // MOVIMENTO 1
        paramKeys.Add("1151");
        paramKeys.Add("1161");
        paramKeys.Add("1171");
        paramKeys.Add("1181");
        paramKeys.Add("1191");
        paramKeys.Add("1201");
        paramKeys.Add("1202");

        paramKeys.Add("0099");
 
    }

    public int[] SearchParamValue(string key)
    {
        //Returns the value of a parameter by it's key. If there are none, it will create one with the value 0000
        for(int i = 0; i < parameterList.Count; i++)
        {
            //Search for the key in all stored parameters
            if(string.Equals(key, parameterList[i].key))
                return parameterList[i].value;
        }

        //If there is no parameter...
        return null;
        
    }

    public bool SetParam(string key, int[] value)
    {

        //Check if the new parameter is outside of the allowed list
        bool wasKeyFound = false;
        foreach (string paramkey in paramKeys)
        {
            if(string.Equals(key, paramkey) == true)
                wasKeyFound = true;
        }

        //if no match was found, return false and loses
        if(wasKeyFound == false)
        {
            WinLogic.Instance.AutoLose();
            return false;
        }

        //Search for the parameter
        foreach (Parameter param in parameterList)
        {
            if (param.key == key)
            {
                //If found, update the value and return
                for (int i = 0; i <= 3; i++)
                    param.value[i] = value[i];

                return true;
            }
        }

        //If there were no keys found, add one
        parameterList.Add(new Parameter(key, value[0], value[1], value[2], value[3]));

        return false;

    }

    public bool CheckWinningParams()
    {
        int winCount = 0;

        List<Parameter> rightParam = new List<Parameter>();

        // --- LIBERA ACESSO
        rightParam.Add(new Parameter("0000", 0, 0, 0, 5) );
        rightParam.Add(new Parameter("0204", 0, 0, 1, 3) );

        // --- MODO POSICIONADOR
        rightParam.Add(new Parameter("0385", 0, 0, 2, 2) );
        rightParam.Add(new Parameter("0202", 0, 0, 0, 3) );
        rightParam.Add(new Parameter("1070", 0, 0, 0, 0) );
        rightParam.Add(new Parameter("1081", 0, 0, 0, 1) );
        rightParam.Add(new Parameter("1101", 0, 0, 0, 1) );
        rightParam.Add(new Parameter("1102", 0, 0, 0, 0) );

        rightParam.Add(new Parameter("1151", 0, 0, 0, 3) );
        rightParam.Add(new Parameter("0099", 0, 0, 0, 1) );

        int[] compareValue = new int[4];

        for (int  i = 0; i < rightParam.Count ; i++)
        {
            //Look for the parameter key and return the comparative value to this variable
            compareValue = SearchParamValue(rightParam[i].key);

            // If null, the student failed
            if (compareValue == null)
                return false;

            //If true, compare the right value to the current value
            for (int j = 0; j < compareValue.Length; j++)
            {
                if (rightParam[i].value[j] != compareValue[j])
                    return false;
            }

            //If There is nothing wrong, increment winning counter 
            winCount++;
        }

        if (IsValueZero("1171") == false)
            winCount++;

        if (IsValueZero("1181") == false)
            winCount++;

        if (IsValueZero("1191") == false)
            winCount++;

        if (IsValueZero("1201") == false)
            winCount++;

        if (IsValueZero("1202") == false)
            winCount++;

        if (SearchParamValue("1161") != null)
            winCount++;

        print($"Winning number: {winCount}");

        if (winCount == 16)
            return true;
        else
            return false;
    }

    public bool IsValueZero(string key) //Use to find out it a value int[] is different from "0000"
    {  
        int[] compareValue = SearchParamValue(key);
        int winCount = 0;

        for (int j = 0; j < compareValue.Length; j++)
        {
            if (compareValue[j] != 0)
                winCount++;
        }

        if (winCount >= 1)
            return false; // Value is not zero
        else
            return true; // value is zero

        //return true;
    }

    public void AddWinningParams()  //Add the winning parameters only to test in editor
    {
        if(parameterList == null)
            parameterList = new List<Parameter>();
        else
            parameterList.Clear();

        // --- LIBERA ACESSO
        parameterList.Add(new Parameter("0000", 0, 0, 0, 5));
        parameterList.Add(new Parameter("0204", 0, 0, 1, 3));

        // --- MODO POSICIONADOR
        parameterList.Add(new Parameter("0385", 0, 0, 2, 2));
        parameterList.Add(new Parameter("0202", 0, 0, 0, 3));
        parameterList.Add(new Parameter("1070", 0, 0, 0, 0));
        parameterList.Add(new Parameter("1081", 0, 0, 0, 1));
        parameterList.Add(new Parameter("1101", 0, 0, 0, 1));
        parameterList.Add(new Parameter("1102", 0, 0, 0, 0));

        parameterList.Add(new Parameter("1151", 0, 0, 0, 3));
        parameterList.Add(new Parameter("1161", 0, 0, 0, 3));
        parameterList.Add(new Parameter("1171", 0, 0, 0, 1));
        parameterList.Add(new Parameter("1181", 0, 0, 0, 1));
        parameterList.Add(new Parameter("1191", 0, 0, 0, 1));
        parameterList.Add(new Parameter("1201", 0, 0, 0, 1));
        parameterList.Add(new Parameter("1202", 0, 0, 0, 1));

        parameterList.Add(new Parameter("0099", 0, 0, 0, 1));
    }
    public void DeleteParameters(){ parameterList?.Clear(); }  //Clean parameters list

    void PrintParam(string key, int v0, int v1, int v2, int v3){ print($"{key}, {v0}{v1}{v2}{v3}"); } //Print parameters for debug purposes

    public void UpdateParamPanel() 
    {
        //Display the parameters
        string paramDisplay = null;

        for(int i = 0; i < parameterList?.Count; i++)
            paramDisplay += $"P{parameterList[i].key} = {parameterList[i].value[0]}{parameterList[i].value[1]}{parameterList[i].value[2]}{parameterList[i].value[3]} \n";

        _paramPanel.text = paramDisplay;
    }


}
