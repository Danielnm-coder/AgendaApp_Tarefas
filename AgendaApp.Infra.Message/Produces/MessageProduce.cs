using AgendaApp.Domain.Dtos.Responses;
using AgendaApp.Domain.Interfaces.Messages;
using AgendaApp.Infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace AgendaApp.Infra.Messages.Producers
{
    public class MessageProducer : IMessageProducer
    {
        public void Send(CriarPessoaResponse response)
        {
            // Configurando a conexão no servidor do RabbitMQ
            var connectionFactory = new ConnectionFactory
            {
                HostName = RabbitMQSettings.Hostname,
                Port = RabbitMQSettings.Port,
                UserName = RabbitMQSettings.Username,
                Password = RabbitMQSettings.Password,
            };

            // Conectando no servidor
            using (var connection = connectionFactory.CreateConnection())
            {
                // Acessando a fila
                using (var model = connection.CreateModel())
                {
                    // Configurando a fila
                    model.QueueDeclare(
                        queue: RabbitMQSettings.Queue, // Nome da fila
                        durable: true, // Fila que não será excluída
                        autoDelete: false, // Não habilita auto exclusão
                        exclusive: false, // Pode ser uma fila compartilhada
                        arguments: null
                    );

                    // Gravar conteúdo na fila
                    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));

                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey: RabbitMQSettings.Queue,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }
    }
}


