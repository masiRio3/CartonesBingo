

var genRandom = new Random(/*DateTime.Now.Millisecond*/);

var carton = new int[3, 9];


//GENERAMOS 4 CARTONES
for (int i = 1; i < 5; i++)
{
    Console.WriteLine($"             *****CARTON N°{i}*****     ");
    //GENERACION DE NUMEROS PARA CARTON
    for (int columna = 0; columna < 9; columna++)
    {
        for (int fila = 0; fila < 3; fila++)
        {
            int nuevoNumero = 0;
            bool isFindNew = false;

            while (!isFindNew)
            {
                if (columna == 0)
                {
                    nuevoNumero = genRandom.Next(1, 10);
                }

                else if (columna == 8)
                {
                    nuevoNumero = genRandom.Next(80, 91);

                }

                else
                {
                    nuevoNumero = genRandom.Next(columna * 10, columna * 10 + 10);

                }


                //****EVITAR REPETICION!!!******
                // Buscar si el nuevoNumero existe en la columa
                isFindNew = true;
                for (int f2 = 0; f2 < 3; f2++)
                {
                    if (carton[f2, columna] == nuevoNumero)
                    {
                        isFindNew = false;
                        break;
                    }
                }
                // Si salio del bucle y no encontro repetidos isFindNew es true y sale del bucle

            }

            carton[fila, columna] = nuevoNumero;

        }
    }

    // ORDENAR COLUMNAS DE MENOR A MAYOR

    for (int columna = 0; columna < 9; columna++)
    {
        for (int fila = 0; fila < 3; fila++)
        {
            for (int k = fila+1; k < 3; k++)
            {
                if (carton[fila, columna]> carton[k, columna])
                {
                    int aux = carton[fila, columna];
                    carton[fila, columna] = carton[k, columna];
                    carton[k, columna] = aux;

                }
            }
        }
    }

    //ESPACIOS EN BLANCO

    var borrados=0;

    while (borrados<12)
    {
        var filaABorrar = genRandom.Next(0, 3);
        var columnaABorrar = genRandom.Next(0, 9);

        if (carton[filaABorrar,columnaABorrar]==0)
        {
            continue;
        }

        //CONTAMOS CUANTOS CEROS HAY EN ESTA FILA
        int cerosEnFila = 0;
        for (int c = 0; c < 9; c++)
        {
            if (carton[filaABorrar, c] == 0)
            {
                cerosEnFila++;
            }
        }
        // CONTAMOS CUANTOS CEROS HAY EN ESTA COLUMNA
        int cerosEnColumna = 0;
        for (int f = 0; f < 3; f++)
        {
            if (carton[f, columnaABorrar] == 0)
            {
                cerosEnColumna++;
            }
        }

        // CONTAMOS CUANTOS ITEMS HAY EN CADA COLUMNA
        var itemsPorColumna = new int[9] ;
        for (int c = 0; c < 9; c++)
        {
            for (int f = 0; f < 3; f++)
            {
                if (carton[f, c] != 0)
                {
                    itemsPorColumna[c]++;
                }

            }

        }
        // CONTAMOS CUANTAS COLUMNAS HAY CON UN SOLO ITEM
        var columnasConUnItem = 0;
        for (int c = 0; c < 9; c++)
        {
            if (itemsPorColumna[c] == 1)
            {
                columnasConUnItem++;
            }
        }

        //SI YA HAY 4 CEROS EN LA FILA O SI HAY 2 CEROS EN LA COLUMNA NO HAGO NADA
        if (cerosEnFila >= 4 || cerosEnColumna >= 2)
        {
            continue;
        }
        // SI HAY 3 COLUMNAS CON UN SOLO ITEM, A PARTIR DE AHORA DEBO BORRAR SOLO LAS COLUMNAS QUE TIENEN 3 ITEMS
        if (columnasConUnItem == 3 && itemsPorColumna[columnaABorrar] != 3)
        {
            continue;
        }

        //SI NO ENTRO EN LAS OPCIONES ANTERIORES BORRAMOS
        carton[filaABorrar, columnaABorrar] = 0;
        borrados++;


    }

    // MOSTRAMOS EL CARTON
    for (int fila = 0; fila < 3; fila++)
    {
        Console.WriteLine(" -------------------------------------------- ");

        for (int columna = 0; columna < 9; columna++)
        {
            if (columna == 0)
            {
                Console.Write("|");
            }
            if (carton[fila, columna] == 0)
            {
                Console.Write("    |");
            }
            else
            {
                Console.Write($" {carton[fila, columna]:00} |");
            }
        }
        Console.WriteLine();

    }

    Console.WriteLine(" -------------------------------------------- ");

}



