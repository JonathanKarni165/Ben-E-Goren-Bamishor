using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInputField : MonoBehaviour
{
    string output;
    int i;
    int[] numbers = new int[3];
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        initializing(numbers);
        i = 0;
        output = "";
    }

    // Update is called once per frame
    void Update()
    {
        int []arr = new int[i];
        Compare(arr, numbers,i);
        output = string.Join("", arr);
        txt.text = output;
        if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            numbers[i] = 9;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            numbers[i] = 8;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            numbers[i] = 7;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            numbers[i] = 6;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            numbers[i] = 5;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            numbers[i] = 4;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            numbers[i] = 3;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            numbers[i] = 2;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            numbers[i] = 1;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            numbers[i] = 0;
            if (i <= numbers.Length - 1)
                i++;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            initializing(numbers);
            i = 0;
        }

    }
    public static void initializing(int[]arr)
    {
        for(int i=0; i<arr.Length; i++)
        {
            arr[i] = 0;
        }
    }
    public static void Compare(int[]arr,int[]numbers, int index)
    {
        for(int i =0; i< index; i++)
        {
            arr[i] = numbers[i];
        }
    }

}
