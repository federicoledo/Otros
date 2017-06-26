#include <stdio.h>
#include <stdlib.h>
#include "funciones.h"

int main()
{
    int men = 0;
    do
    {
        men = menu();
        switch(men)
        {
            case 1:
                break;
            case 2:
                break;
            case 9:
                printf("Gracias por utilizar el programa\n");
                break;
            default:
                printf("Error al ingresar la opcion, intentelo nuevamente\n");
        }
    }while(men != 9);

    return 0;
}
