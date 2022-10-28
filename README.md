# Challenge-N5
Web Api - App React 
Arturo Ramirez
Ecuador - Guayaquil 

Build Docker app-permisos

cd app-permisos

docker build --compress --platform linux/amd64 -t  <user>/challenge-n5:20221028.1 .

Login docker 

docker login #Colocar el usuario de dockerhub y el appPassword

Push docker 

docker push <user>/challenge-n5:20221028.1

Descargar una imagen de mi repositorio publico 

docker push aramirez1991/challenge-n5:20221028.1

Correr la APP

docker run -d -p 3000:3000 aramirez1991/challenge-n5:20221028.1


Build Docker WebApiPermiso
cd WebApiPermiso

docker build --compress --platform linux/amd64 -t  aramirez1991/challenge-n5-webapipermiso:20221028.1 .
