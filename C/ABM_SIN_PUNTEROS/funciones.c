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

int menu();
void inicializar(eEmpleado lista[]);
int primerLibre(eEmpleado lista[]);
void nuevoEmpleado(eEmpleado lista[], int posicion);
void mostrarEmpleados(eEmpleado lista[]);
void modificarEmpleado(eEmpleado lista[]);
void borrarEmpleado(eEmpleado lista[]);
