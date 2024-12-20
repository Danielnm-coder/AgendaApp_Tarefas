using AgendaApp.Domain.Dtos.Responses;
using AgendaApp.Infra.Messages.Settings;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Messages.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Configurando a conexão no servidor do RabbitMQ
            var connectionFactory = new ConnectionFactory
            {
                HostName = RabbitMQSettings.Hostname,
                Port = RabbitMQSettings.Port,
                UserName = RabbitMQSettings.Username,
                Password = RabbitMQSettings.Password,
            };

            //conectando no servidor e na fila
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            // Configurando a fila
            model.QueueDeclare(
                queue: RabbitMQSettings.Queue, // Nome da fila
                durable: true, // Fila que não será excluída
                autoDelete: false, // Não habilita auto exclusão
                exclusive: false, // Pode ser uma fila compartilhada
                arguments: null
            );

            //objeto para ler e processar a fila
            var consumer = new EventingBasicConsumer(model);

            //executando a leitura dos itens da fila
            consumer.Received += (cons, args) =>
            {
                //ler o conteudo gravado na fila (PAYLOAD)
                var payload = args.Body.ToArray();
                var json = Encoding.UTF8.GetString(payload);

                //desserializando o Json lido da fila
                var pessoa = JsonConvert.DeserializeObject<CriarPessoaResponse>(json); 

                //retirar o item da fila
                model.BasicAck(args.DeliveryTag, false);  
            };

            //finalizando a leitura
            model.BasicConsume(
                queue: RabbitMQSettings.Queue,
                autoAck: false, //não remover itens da fila automaticamente
                consumer: consumer
                );
        }
    }
}



