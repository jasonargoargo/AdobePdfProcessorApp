﻿using DataLibrary.Models;
using Dapper;
using System.Data;
using DataLibrary.DbAccess;

namespace DataLibrary.DbServices;

public class AddressSqlDataService : IAddressDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressSqlDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task CreateOrUpdateFromSpecPrintFile(AddressModel addressModel)
    {
        var parms = new
        {
            addressModel.AccountId,
            addressModel.Ward,
            addressModel.Section,
            addressModel.Block,
            addressModel.Lot,
            addressModel.LandUseCode,
            addressModel.YearBuilt
        };
        await _unitOfWork.Connection.ExecuteAsync("spAddress_CreateOrUpdateSpecPrintFile", parms,
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
    }
    public async Task CreateOrUpdateFromSDATRedeemedFile(AddressModel addressModel)
    {
        var parms = new
        {
            addressModel.AccountId,
            addressModel.IsRedeemed
        };
        await _unitOfWork.Connection.ExecuteAsync("spAddress_CreateOrUpdateSDATRedeemedFile", parms,
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
    }
    public async Task<bool> CreateOrUpdateGroundRentJasonFromSDATIsGroundRent(AddressModel addressModel)
    {
        try
        {
            var parms = new
            {
                addressModel.AccountId,
                addressModel.IsGroundRent
            };
            await _unitOfWork.Connection.ExecuteAsync("spGroundRentBaltimoreCity_CreateOrUpdateSDATIsGroundRent", parms,
                commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<bool> CreateOrUpdateGroundRentAmandaFromSDATIsGroundRent(AddressModel addressModel)
    {
        try
        {
            var parms = new
            {
                addressModel.AccountId,
                addressModel.IsGroundRent
            };
            await _unitOfWork.Connection.ExecuteAsync("spGroundRentBaltimoreCityAmanda_CreateOrUpdateSDATIsGroundRent", parms,
                commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<AddressModel> ReadAddressByAccountId(int accountId)
    {
        return (await _unitOfWork.Connection.QueryAsync<AddressModel>("spAddress_ReadByAccountId", new { AccountId = accountId },
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction)).FirstOrDefault();
    }
    public async Task<List<AddressModel>> ReadGroundRentJasonTopAmountWhereIsGroundRentNull()
    {
        return (await _unitOfWork.Connection.QueryAsync<AddressModel>("spGroundRentBaltimoreCity_ReadTop60000WhereIsGroundRentNull", null,
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction)).ToList();
    }
    public async Task<List<AddressModel>> ReadGroundRentAmandaTopAmountWhereIsGroundRentNull()
    {
        return (await _unitOfWork.Connection.QueryAsync<AddressModel>("spGroundRentBaltimoreCityAmanda_ReadTop60000WhereIsGroundRentNull", null,
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction)).ToList();
    }
    public async Task DeleteAddress(int accountId)
    {
        await _unitOfWork.Connection.ExecuteAsync("spAddress_Delete", new { AccountId = accountId },
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
    }
}
