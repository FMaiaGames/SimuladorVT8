using System.Collections.Generic;
using UnityEngine;

public class ParameterObj : MonoBehaviour
{
    public static ParameterObj Instance;
    public List<Parameter> parameter;

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

        parameter = new List<Parameter>();

        /*
        // --- LIBERA ACESSO
        parameter.Add(new Parameter("0000", 0, 0, 0, 5) );
        parameter.Add(new Parameter("0204", 0, 0, 1, 3) );

        // --- MODO POSICIONADOR
        parameter.Add(new Parameter("0385", 0, 0, 2, 2) );
        parameter.Add(new Parameter("0202", 0, 0, 0, 3) );
        parameter.Add(new Parameter("1070", 0, 0, 0, 0) );
        parameter.Add(new Parameter("1081", 0, 0, 0, 1) );
        parameter.Add(new Parameter("1101", 0, 0, 0, 1) );
        parameter.Add(new Parameter("1102", 0, 0, 0, 0) );

        // --- MOVIMENTO 1
        parameter.Add(new Parameter("1151", 0, 0, 0, 3) );
        parameter.Add(new Parameter("1161", 0, 0, 0, 0) );
        parameter.Add(new Parameter("1171", 8, 1, 9, 2) );
        parameter.Add(new Parameter("1181", 0, 0, 0, 3) );
        parameter.Add(new Parameter("1191", 0, 1, 0, 0) );
        parameter.Add(new Parameter("1201", 5, 0, 0, 0) );

        parameter.Add(new Parameter("0099", 0, 0, 0, 1) );
        */
    }

    public int[] SearchParam(string key)
    {
        for(int i = 0; i <= parameter.Count; i++)
        {
            if(string.Equals(key, parameter[i].key))
            {
                return parameter[i].value;
            }
            else
            {
                int[] tmpParam = new int[4];
                for (int j = 0; j < tmpParam.Length; j++)
                    tmpParam[j] = 0;

                return tmpParam;
            }
        }
        return null;
    }

    public void SetParam(string key, int[] value)
    {
        foreach(Parameter param in parameter)
        {
            if (string.Equals(key, param.key))
            {
                parameter.Remove(param);
                parameter.Add(new Parameter(key, value[0], value[1], value[2], value[3]));
            }
            else
            {
                //mensagem de erro
            }
        }
    }

    public int CheckWinningParams()
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

        // --- MOVIMENTO 1
        winningParameter.Add(new Parameter("1151", 0, 0, 0, 3) );
        winningParameter.Add(new Parameter("1161", 0, 0, 0, 0) );
        winningParameter.Add(new Parameter("1171", 8, 1, 9, 2) );
        winningParameter.Add(new Parameter("1181", 0, 0, 0, 3) );
        winningParameter.Add(new Parameter("1191", 0, 1, 0, 0) );
        winningParameter.Add(new Parameter("1201", 5, 0, 0, 0) );

        winningParameter.Add(new Parameter("0099", 0, 0, 0, 1) );


        for(int  i = 0; i <= winningParameter.Count; i++)
        {

            int[] compareVallue = SearchParam(winningParameter[i].key);

            if(compareVallue == winningParameter[i].value)
            {
                winningCount++;
            }
            else
            {
                winningCount = 0;
                return 15;
            }
        }

        return 15;

    }

    public void AddWinningParams()
    {
        parameter.Clear();

        // --- LIBERA ACESSO
        parameter.Add(new Parameter("0000", 0, 0, 0, 5));
        parameter.Add(new Parameter("0204", 0, 0, 1, 3));

        // --- MODO POSICIONADOR
        parameter.Add(new Parameter("0385", 0, 0, 2, 2));
        parameter.Add(new Parameter("0202", 0, 0, 0, 3));
        parameter.Add(new Parameter("1070", 0, 0, 0, 0));
        parameter.Add(new Parameter("1081", 0, 0, 0, 1));
        parameter.Add(new Parameter("1101", 0, 0, 0, 1));
        parameter.Add(new Parameter("1102", 0, 0, 0, 0));

        // --- MOVIMENTO 1
        parameter.Add(new Parameter("1151", 0, 0, 0, 3));
        parameter.Add(new Parameter("1161", 0, 0, 0, 0));
        parameter.Add(new Parameter("1171", 8, 1, 9, 2));
        parameter.Add(new Parameter("1181", 0, 0, 0, 3));
        parameter.Add(new Parameter("1191", 0, 1, 0, 0));
        parameter.Add(new Parameter("1201", 5, 0, 0, 0));

        parameter.Add(new Parameter("0099", 0, 0, 0, 1));
    }


}
