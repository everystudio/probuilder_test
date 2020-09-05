using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTest : MonoBehaviour
{
    public Text m_txt;
    public Text m_txtCheck;

    public int[] result_num = new int[7];


    public static int GetArrayIndex(int[] _prob_array)
    {

        int total_prob = 0;
        foreach (int prob in _prob_array)
        {
            total_prob += prob;
        }
        int temp_rand_param = Random.Range(0, total_prob);
        int result = 0;
        for (int i = 0; i < _prob_array.Length; i++)
        {
            temp_rand_param -= _prob_array[i];
            if (temp_rand_param < 0)
            {
                result = i;
                break;
            }
        }

        
        return result;
    }

    void Start()
    {
        for (int i = 0; i < 0; i++)
        {
            result_num[i] = 0;
        }
        StartCoroutine(check_root(6000));
    }

    IEnumerator check_root(int _check_num)
    {
        for( int i = 0; i < _check_num; i++)
        {
            yield return StartCoroutine(check());
            m_txtCheck.text = string.Format(
                "1:{0:0.00} 2:{1:0.00} 3:{2:0.00} 4:{3:0.00} 5:{4:0.00} 6:{5:0.00} 7:{6:0.00}",
                (float)result_num[0]/(float)(i+1),
                (float)result_num[1]/(float)(i + 1),
                (float)result_num[2]/ (float)(i + 1),
                (float)result_num[3]/ (float)(i + 1),
                (float)result_num[4]/ (float)(i + 1),
                (float)result_num[5]/ (float)(i + 1),
                (float)result_num[6] / (float)(i + 1)
                );
        }
    }

    IEnumerator check()
    {
        List<int> resutl_list = new List<int>();
        resutl_list.Clear();
        int[] prob_arr = new int[7];
        for (int i = 0; i < prob_arr.Length; i++)
        {
            prob_arr[i] = 100;
        }

        for (int i = 0; i < prob_arr.Length; i++)
        {
            int get_index = GetArrayIndex(prob_arr);

			#region 検証用
			if ( i == 0)
            {
                result_num[get_index] += 1;
            }
			#endregion

			prob_arr[get_index] = 0;
            resutl_list.Add(get_index + 1);
        }
        string str_result = "";
        foreach (int buf in resutl_list)
        {
            str_result += buf.ToString();
        }
        //Debug.Log(str_result);
        m_txt.text = str_result;

        yield return null;
    }






    /*
    List<int> set = new List<int>();
    set.Clear();

    int loop = 0;
    while( set.Count < 7 )
    {
        loop += 1;
        int temp = Random.Range(1, 8);
        if(!set.Contains(temp))
        {
            set.Add(temp);
            loop = 0;
        }
        if (100 < loop)
        {
            Debug.LogError("ループ回数が既定値を超えました");
            break;
        }
    }
    string result = "";
    foreach( int buf in set)
    {
        result += buf.ToString();
    }
    Debug.Log(result);
    m_txt.text = result;
    */

}
