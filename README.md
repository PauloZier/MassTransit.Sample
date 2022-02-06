<h1 align="center">MassTransit.Sample</h1>

<p align="center">
    Este é um projeto para exemplo de uso do MassTransit juntamente com RabbitMQ
</p>

# Descrição

- Shared.Models

    Biblioteca de classes para modelos das aplicações

- ContactPublisher

    Api para publicar um contato na fila de mensagens do RabbitMQ

- ContactConsumer

    Aplicação que consome a fila de mensagens do RabbitMQ

# Clonar este repositório

```sh
git clone git@github.com:PauloZier/MassTransit.Sample.git
```

# Executar via Docker

```sh
docker-compose build && docker-compose up
```

