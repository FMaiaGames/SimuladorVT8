using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARSubsystems;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ParameterObj : MonoBehaviour
{
    public static ParameterObj Instance;
    public List<Parameter> parameterList;

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

    private void Awake()
    {
        Instance = this;
        parameterList = new List<Parameter>();
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

        //If there is no parameter, create one with the value 0000
        int[] tmpParam = new int[4];
        for (int j = 0; j < tmpParam.Length; j++)
            tmpParam[j] = 0;

        return tmpParam;
        
    }

    public void SetParam(string key, int[] value)
    {
        //Search for the parameter
        foreach (Parameter param in parameterList)
        {
            if (param.key == key)
            {
                //If found, update the value and return
                for (int i = 0; i <= 3; i++)
                    param.value[i] = value[i];

                return;
            }
        }

        //If there were no keys found, add one
        parameterList.Add(new Parameter(key, value[0], value[1], value[2], value[3]));

    }

    public bool CheckWinningParams()
    {
        int winningCount = 0;

        List<Parameter> winningParameter = new List<Parameter>();

        // --- LIBERA ACESSO
        winningParameter.Add(new Parameter("0000", 0, 0, 0, 5) );
        winningParameter.Add(new Parameter("0204", 0, 0, 1, 3) );

        // --- MODO POSICIONADOR
        winningParameter.Add(new Parameter("0385", 0, 0, 2, 2) );
        winningParameter.Add(new Parameter("0202", 0, 0, 0, 3) );
        winningParameter.Add(new Parameter("1070", 0, 0, 0, 0) );
        winningParameter.Add(new Parameter("1081", 0, 0, 0, 1) );
        winningParameter.Add(new Parameter("1101", 0, 0, 0, 1) );
        winningParameter.Add(new Parameter("1102", 0, 0, 0, 0) );

        winningParameter.Add(new Parameter("1151", 0, 0, 0, 3) );
        winningParameter.Add(new Parameter("0099", 0, 0, 0, 1) );

        int[] compareValue = new int[4];

        for (int  i = 0; i <= winningParameter.Count - 1 ; i++)
        {
            //Look for the parameter key and return the comparative value to this variable
            compareValue = SearchParamValue(winningParameter[i].key);

            // If null, the student failed
            if (compareValue == null)
                return false;


            //If true, compare the right value to the current value
            for (int j = 0; j < compareValue.Length; j++)
            {
                if (winningParameter[i].value[j] != compareValue[j])
                    return false;
            }

            return true;
        }

        print($"Winning number: {winningCount}");

        if (winningCount == 15)
            return true;
        else
            return false;
    }

    public void AddWinningParams()  //Add the winning parameters only to test in editor
    {
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
        parameterList.Add(new Parameter("0099", 0, 0, 0, 1));
    }

    public void DeleteParameters(){ parameterList?.Clear(); }  //Clean parameters list

    void PrintParam(string key, int v0, int v1, int v2, int v3){ print($"{key}, {v0}{v1}{v2}{v3}"); } //Print parameters for debug purposes

    public void UpdateParamPanel() 
    {
        //Display the parameters
        string paramDisplay = null;

        for(int i = 0; i < parameterList.Count; i++)
            paramDisplay += $"P{parameterList[i].key} = {parameterList[i].value[0]}{parameterList[i].value[1]}{parameterList[i].value[2]}{parameterList[i].value[3]} \n";

        _paramPanel.text = paramDisplay;
    }


}
