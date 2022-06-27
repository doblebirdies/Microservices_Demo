# Microservices Demo

## Proyecto con dos microservicios para mostrar ejemplo de comunicación

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
	
	b) Si hay stcok el productor "CrearPedido" envía un mensaje a la cola "OrderCreated" a la que está suscrito el consumidor "ProductConsumer".

2) Este consumidor "ProductConsumer" una vez preparado el pedido emite una notificación mediante CQRS:

	a) Envía un mensaje a la cola "OrderPrepared", a la que está suscrito el consumidor "OrderConsumer" que enviará un correo al cliente indicando que su pedido ya está preparado
	
	b) Ejecuta la opción de emvia rpedido (simulada con sleep) y envía un mensaje a la cola "OrderShipped" para enviar correo al cliente.

Como podemos ver, tenemos comandos, consultas y notificaciones con CQRS, comunicación con mensajería de colas con RabbitMQ y comunicación por http con Refit.

