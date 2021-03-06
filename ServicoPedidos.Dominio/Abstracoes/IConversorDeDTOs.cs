﻿using ServicoPedidos.Dominio.Abstracoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoPedidos.Dominio
{
    public interface IConversorDeDTOs
    {
        Task<IItemDePedido> ConverteParaItemAsync(IItemDePedidoDTO itemDTO);
        IItemDePedidoDTO ConverterParaDTO(IItemDePedido item);
        IPedidoDTO ConverterParaDTO(IPedido pedido);
        Task<IPedido> ConverterParaPedidoAsync(IPedidoDTO pedidoDTO);
        ICliente ConverterParaCliente(IClienteDTO clienteBD);
        IProduto ConverterParaProduto(IProdutoDTO produtoBD);
        Task<IEnumerable<IPedido>> ConverterParaPedidosAsync(IEnumerable<IPedidoDTO> pedidosDTO);
    }
}