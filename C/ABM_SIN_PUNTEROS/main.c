#include <stdio.h>
#include <stdlib.h>
#include "funciones.h"

int main()
{
    int men, posicion;
    eEmpleado listaEmpleados[50];
    printf("=========================Bienvenido!!=========================");
    getchar();
    inicializar(listaEmpleados);
    do
    {
        system("cls");
        men = menu();
        switch(men)
        {
            case 1:
                system("cls");
                posicion = primerLibre(listaEmpleados);
                nuevoEmpleado(listaEmpleados, posicion);
                fflush(stdin);
                printf("Presione una tecla para continuar\n");
                getchar();
                break;
            case 2:
                system("cls");
                modificarEmpleado(listaEmpleados);
                fflush(stdin);
                printf("Presione una tecla para continuar\n");
                getchar();
                break;
            case 3:
                system("cls");
                mostrarEmpleados(listaEmpleados);
                fflush(stdin);
                printf("Presione una tecla para continuar\n");
                getchar();
                break;
            case 4:
                system("cls");
                fflush(stdin);
                borrarEmpleado(listaEmpleados);
                printf("Presione una tecla para continuar\n");
                getchar();
                break;
            case 9:
                system("cls");
                break;
            default:
                system("cls");
                printf("Error, seleccione una opcion correcta\n");
        }
    }while(men!=9);
    system("cls");
    printf("Gracias por utilizar el programa");
    return 0;
}
