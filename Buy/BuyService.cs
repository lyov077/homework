using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using FirstProject.Contracts.Buy.ContractDefinition;

namespace FirstProject.Contracts.Buy
{
    public partial class BuyService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BuyDeployment buyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BuyDeployment>().SendRequestAndWaitForReceiptAsync(buyDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BuyDeployment buyDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BuyDeployment>().SendRequestAsync(buyDeployment);
        }

        public static async Task<BuyService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BuyDeployment buyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, buyDeployment, cancellationTokenSource);
            return new BuyService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BuyService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BuyTokenRequestAsync(BuyTokenFunction buyTokenFunction)
        {
             return ContractHandler.SendRequestAsync(buyTokenFunction);
        }

        public Task<string> BuyTokenRequestAsync()
        {
             return ContractHandler.SendRequestAsync<BuyTokenFunction>();
        }

        public Task<TransactionReceipt> BuyTokenRequestAndWaitForReceiptAsync(BuyTokenFunction buyTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyTokenFunction, cancellationToken);
        }

        public Task<TransactionReceipt> BuyTokenRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<BuyTokenFunction>(null, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> PriceQueryAsync(PriceFunction priceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceFunction, BigInteger>(priceFunction, blockParameter);
        }

        
        public Task<BigInteger> PriceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SellTokenRequestAsync(SellTokenFunction sellTokenFunction)
        {
             return ContractHandler.SendRequestAsync(sellTokenFunction);
        }

        public Task<TransactionReceipt> SellTokenRequestAndWaitForReceiptAsync(SellTokenFunction sellTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellTokenFunction, cancellationToken);
        }

        public Task<string> SellTokenRequestAsync(BigInteger amount)
        {
            var sellTokenFunction = new SellTokenFunction();
                sellTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(sellTokenFunction);
        }

        public Task<TransactionReceipt> SellTokenRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var sellTokenFunction = new SellTokenFunction();
                sellTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellTokenFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }
    }
}
