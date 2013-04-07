ConcesionarioVirtual
====================

Concesionario virtual implementado en C# usando OpenGL y el framework TAO. 

![Imagen](/img/captura.png "Imagen")

El coche es un archivo creado en 3dStudio Max y cargado en la aplicacion mediante su descomposición en poligonos.

A los diferentes objetos que componen el modelo 3ds se les realizan cambios en los materiales, asi como 
transformaciones como rotar y trasladar, ademas de otras acciones como cliping , para conseguir lograr representar 
el modelo de diversas maneras. 

Tambien se usan otras posibilidades como un pequeño sistema de particulas para el humo del motor y el stencil buffer 
para el reflejo del mismo en la supericie que lo sostiene. 

La escena cuenta con tres luces: una ambiental, una direccional ubicada cerca de la camara, en el origen y una tercera 
sobre el vehiculo para permitir la mejor visualizacion del interior del mismo. 

De la misma forma se usan varias texturas para modelar el lugar y el interior del coche. 

Para manipular la exposición se brinda una ventana hija “control remoto” que es bastante autoexplicativa. 
Ademas hay un conjunto de teclas a las que la aplicación respondera. Estas son:

R: Oculta o/ Muestra el Control Remoto
X,y,z: Seleccionan un eje.
I,d: Incrementan y decrementan la rotacion para el eje seleccionado
N,m: Mueven la camara adelante/atrás en el eje Z
  : Mueven la camara adelante/atrás en el eje X
  : Mueven la camara adelante/atrás en el eje Y
q:Enciende/Apaga la luz del bombillo que acompa;a la camara
w:Enciende/Apaga la luz ambiental
