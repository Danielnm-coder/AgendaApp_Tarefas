using AgendaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para enviar dados para uma fila do RabbitMQ
    /// </summary>
    public interface IMessageProducer
    {
        /// <summary>
        /// Método para gravar os dados na fila
        /// </summary>
        /// <param name="response">Dados de pessoa que serão gravados</param>
        void Send(CriarPessoaResponse response);
    }
}



