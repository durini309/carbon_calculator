# Calculadora de carbono
El 
Detalle del procedimiento para realizar la medicion de captura de carbono en la biomasa forestal. 

## Calculo de carbono presente
El calculo se divide en dos pasos simples:

* Calculo de volumen maderable
* Calculo de contenido de carbono

### Calculo de volumen maderable
Primero se realiza el calculo del area basal en cada una de las unidades muestrales.
El área basal (AB) es la sumatoria de las áreas transversales de todos los árboles con
un diámetro mayor a 10 cm existentes en el área definida (héctarea) y se expresa en m^2/ha

[Formula de documento de AB](https://github.com/durini309/carbon_calculator/blob/master/medicion_simple.pdf)

[Formula de documento de AB](https://github.com/durini309/carbon_calculator/blob/master/medicion_simple.pdf)

### Calculo de contenido de carbono
El carbono se obtiene del producto del volumen multiplicado por el contenido de materia seca
(%MS( y por el cotenido de carbono en la MS (% C = 50% aceptado por el IPCC). 

[Formula de documento de C](https://github.com/durini309/carbon_calculator/blob/master/medicion_simple.pdf)

**A esta cantidad de Carbono se le aplica el Factor de Extensión de la biomasa**

## Calculo de carbono proyectado

Para realizar las proyecciones de cálculo de carbono se utilizaron las formulas en funcion del tiempo encontradas en este [estudio](www.google.com) teórico. 

Para cada especie definida se tenían formulas especificas de como calcular el valor del carbono en el tiempo.
En este espacio documentaremos como se realizaban los calculos de la especie **Pino candelillo**:

* Altura dominante (m): Exp(Ln(s) - 6.96328*(1/T - 0.1))
* Diámetro (cm): Exp(2.853221 - 5.94932/T + 0.055943*S - 0.000218*N)
* Área basal (m2/ha): Exp(1.91575 - 11.592777/T + 0.100823*S + 0.000843*N)
* Volumen total (m3/ha): Exp(3.160695 - 18.203956/T + 0.182736*S + 0.000775*N)
* Contenido de carbono: Volumen total * (% Materia Seca) * (CMS).

Donde S es el indice de sitio, T es el tiempo, N es la cantidad de árboles.

Estas formulas nos permitian obtener los datos precisos de cada una de las variables en los diferentes
años y de esa manera se podía proyectar en una gráfica.

