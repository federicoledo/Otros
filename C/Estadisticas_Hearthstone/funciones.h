#include <stdio.h>
#include <stdlib.h>

int menu()
{
    int aux;
    printf("Que desea realizar?\n1.Agregar una nueva partida\n2.Mostrar estadisticas\n9.Salir\n");
    scanf("%d", &aux);
    return aux;
}
