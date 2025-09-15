using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Primero : MonoBehaviour
{


    [SerializeField]private int _variableInt = 5; //numeros, el serializefield es para poner las cosas privadas dentro del inspector que se vean
    public float varibalefloat = 6f; // numeros con decimales 

    public string variableString = "Hola mundo";

    public bool variableBool = false;

    public int[] arrayInt = new int[5] {12, 4, 8, 9, 0};  // conjunto de cajas, los corchetes es para dar valor a los elementos

    public List<int> listInt = new List<int>(9) {3, 7, 9}; // lista para guardar y quitar elementos 


    private void Start()
    {
        int numero = 5; // crear variables dentro de funciones es solo para utilizarlas aquí

        if (numero == 7) // dentro del parentesis la condicion que quieras para que se ejecute el codigo
        {
            //
            //
            //
        }

        else if (numero == 3)
        {
            //
            //
            //
        }
        else
        {

        }

        if (numero == 7)
            transform.position = Vector3.zero; // sin los corchetes es solo para ejecutar una linea de codigo


        // foreach (var item in collection) 
        {

        }
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
