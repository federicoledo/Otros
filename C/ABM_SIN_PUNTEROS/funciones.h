#include <stdio.h>
#include <stdlib.h>

typedef struct eEmpleado
{
    char apellido[20];
    char puesto[50];
    int legajo;
    int edad;
    int dni;
    int sueldo;
    int estado;
}eEmpleado;

int menu()
{
    int opc;
    printf("Que desea realizar?\n1.Ingresar nuevo empleado\n2.Modificar empleado\n3.Mostrar empleados agendados\n4.Borrar empleado\n9.Salir\n");
    scanf("%d", &opc);
    return opc;
}

void inicializar(eEmpleado lista[])
{
    for(int i=0; i<50; i++)
    {
        lista[i].estado = 0;
        lista[i].legajo = -1;
    }
}

int primerLibre(eEmpleado lista[])
{
    for(int i=0; i<50; i++)
    {
        if(lista[i].estado == 0)
            return i;
        if(lista[20].estado == 1)
        {
            printf("No hay espacios libres\n");
            return -1;
        }
    }
}



void nuevoEmpleado(eEmpleado lista[], int posicion)
{
    int aux;
    printf("Ingrese el legajo\n");
    scanf("%d", &aux);
    for(int i=0; i<50; i++)
    {
        while(lista[i].legajo == aux)
        {
            printf("Error, el legajo ya se encuentra ingresado, ingreselo nuevamente\n");
            i = 0;
            scanf("%d", &aux);
        }
    }
    while(aux < 1)
    {
        printf("Error, el legajo debe ser positivo, ingreselo nuevamente\n");
        scanf("%d", &aux);
    }
    lista[posicion].legajo = aux;

    printf("Ingrese el apellido\n");
    fflush(stdin);
    gets(lista[posicion].apellido);

    printf("Ingrese el puesto\n");
    fflush(stdin);
    gets(lista[posicion].puesto);

    printf("Ingrese el dni\n");
    scanf("%d", &lista[posicion].dni);
    while(lista[posicion].dni < 0)
    {
        printf("Error, el DNI no puede ser negativo, ingreselo nuevamente\n");
        scanf("%d", &lista[posicion].dni);
    }

    printf("Ingrese la edad\n");
    scanf("%d", &lista[posicion].edad);
    while(lista[posicion].edad < 0 || lista[posicion].edad > 75)
    {
        printf("Error, la edad ingresada no es válida, ingresela nuevamente\n");
        scanf("%d", &lista[posicion].edad);
    }

    printf("Ingrese el sueldo\n");
    scanf("%d", &lista[posicion].sueldo);
    while(lista[posicion].sueldo < 0)
    {
        printf("Error, el sueldo no puede ser negativo, ingreselo nuevamente\n");
        scanf("%d", &lista[posicion].sueldo);
    }

    lista[posicion].estado = 1;

}


void mostrarEmpleados(eEmpleado lista[])
{
    for(int i=0; i<50; i++)
    {
        if(lista[i].estado == 1)
            printf("[%d]\nLegajo: %d\nApellido: %s\nPuesto: %s\nDNI: %d\nEdad: %d\nSueldo: %d\n------------------\n", i+1, lista[i].legajo, lista[i].apellido, lista[i].puesto, lista[i].dni, lista[i].edad, lista[i].sueldo);
    }
}

void modificarEmpleado(eEmpleado lista[])
{
    int modificar;
    for(int i=0; i<50; i++)
    {
        if(lista[i].estado == 1)
            printf("[%d].%d\n", i+1, lista[i].legajo);
    }
    printf("Ingrese el numero asignado al legajo que desee modificar\n");
    scanf("%d", &modificar);
    for(int i=1; i<50; i++)
    {
        if(i == modificar && lista[i-1].estado == 1)
        {
            nuevoEmpleado(lista, modificar-1);
            break;
        }
        if((i == modificar  && lista[i-1].estado!=1) || modificar > 50)
        {
            printf("Error al seleccionar la opcion, intentelo nuevamente\n");
            scanf("%d", &modificar);
            i = 0;
        }
    }
}

void borrarEmpleado(eEmpleado lista[])
{
    int borrar;
    int aux;
    for(int i=0; i<50; i++)
    {
        if(lista[i].estado == 1)
        {
            printf("[%d].%d\n", i+1, lista[i].legajo);
            aux = 0;
        }
        if(i == 20 && lista[20].estado == 0 && aux != 0)
        {
            printf("No hay empleados cargados\n");
            aux=1;
        }
    }
    if(aux == 0)
    {
        printf("Ingrese el numero asignado al legajo que desee borrar\n");
        scanf("%d", &borrar);
        for(int i=1; i<50; i++)
        {
            if(i == borrar && lista[i-1].estado == 1)
            {
                lista[i-1].estado = 0;
                lista[i-1].legajo = -1;
                break;
            }
            if((i == borrar  && lista[i-1].estado!=1) || borrar > 50)
            {
                printf("Error al seleccionar la opcion, intentelo nuevamente\n");
                scanf("%d", &borrar);
                i = 0;
            }
        }
    }
}
