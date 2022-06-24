# Microservices Demo

##Proyecto con dos microservicios para mostrar ejemplo de comunicación

En primer lugar simulamos un microservicios de una tienda ms.shop con sus acciones de CrearPedido, BorrarPedido. 
Utilizamos el patrón CQRS, una base de datos SQLServer y aunque no está implementado así por no ser el objetivo del ejemplo, 
esto debería estar creado en un contenedor Docker.

En segundo lugar tenemos un microservicio almacén ms.storage, donde se dispone de las acciones PrepararPedido, EnviarPedido y VerificarStock.
En este caso se utiliza tambien una base de datos SQLServer por simplicidad, pero podría ser otra base de datos cualquiera y lógicamente debería estar
igualmente en un contenedor Docker.

Para la comunicación tenemos un proyecto compartido ms.communications, donde se utiliza como cola de mensajería
RabbitMQ: 

1) La acción "CrearPedido" se comunica con el microservicio almacén mediante http utilizando Redfit para verificar si hay stock con la acción "StockDisponible" :

	a) Si no hay stock emite una notificación mediante el patrón CQRS avisando al cliente de que su pedido no puede ser enviado. 
	b) Si hay stcok el productor "CrearPedido" envía un mensaje a la cola "Pedidos" a la que está suscrito el consumidor "PrepararPedido".

2) Este consumidor "PrepararPedido" una vez termina:

	a)envía un mensaje a la cola "PedidoPreparado", a la que está suscrito el consumidor "AvisarCliente" que enviará un correo al cliente indicando que su pedido ya está listo para enviarse. 
	b)emite una notificación de nuevo con el patron CQRS, que hace una llamada a "EnviarPedido" dentro del mismo servicio

3)El Productor "EnviarPedido" envía un mensaje a la cola "Clientes" 
4)El consumidor "AvisarCliente" leer este mensaje y envía un mensaje al cliente avisando de que su pedido se ha enviado.

Como podemos ver, tenemos notificacione sinternas con CQRS, comunicación con mnesajería de colas con RabbitMQ y comunicación por http con Refit, además tenemos un mismo 
servicio consumiendo de dos colas diferentes, "AvisarCliente", suscrito a la cola "Pedido" y a la cola "Preparado".

El gráfico ..................
