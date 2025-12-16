//using App.Repository;
//using App.Repository.Entities;
//using App.Repository.Repositories;
//using App.Service.Dtos;
//using App.Service.Services;

//using AutoMapper;
//using Azure.Core;
//using Microsoft.EntityFrameworkCore;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace App.Service.Transaction
//{
//    public class TransactionService(IRemindersRepository remindersrepository, IMapper mapper) : IReminderService
//    {
//        public async Task<ServiceResult<ReminderListOutputModel>> CreateTransactionAsync(ReminderCreateInputModel dto)
//        {
//            var newReminder = mapper.Map<Reminder>(ReminderCreateInputModel);
//            newCourse.Created = DateTime.Now;
//            newCourse.UserId = identityService.UserId;

//            // önce DB'ye ekleniyor
//            await transactionRepository.AddAsync(transaction);
//            await IUNiteOf.SaveChangesAsync();

//            // 🔹 DTO oluşturuluyor
//            var responseDto = new CreateTransactionResponse(
//                transaction.Id,
//                transaction.Amount,
//                transaction.Date,
//                mapper.Map<TransactionTypeDto>(transaction.TransactionType),
//                mapper.Map<CurrencyDto>(transaction.Currency)

//            );

//            // 🔹 Redis'e ekleme 
//            var db = redis.GetDatabase();  //normalde her seferinde almayız, constructor'da alırız
//            var cacheKey = $"transaction:{transaction.Id}";
//            var serialized = System.Text.Json.JsonSerializer.Serialize(responseDto);
//            await db.StringSetAsync(cacheKey, serialized, TimeSpan.FromHours(1)); // 1 saat cache süresi

//            return ServiceResult<CreateTransactionResponse>.Success(responseDto);
//            //var transaction = new Repository.Transactions.Transaction()
//            //{
//            //    Amount= dto.Amount,
//            //    Title=dto.Title,
//            //    CurrencyId=dto.CurrencyId,
//            //    TransactionTypeId=dto.TransactionTypeId,
//            //    Date=dto.Date

//            //};
//            //await transactionRepository.AddAsync(transaction);
//            //await ıUNiteOf.SaveChangesAsync();
//            //return ServiceResult<CreateTransactionResponse>.Success(new CreateTransactionResponse(transaction.Id,transaction.Amount,transaction.Date, mapper.Map<TransactionTypeDto>(transaction.TransactionType),
//            //mapper.Map<CurrencyDto>(transaction.Currency)));


//        }

//        public Task<ServiceResult> DeleteTransactionAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<ServiceResult<List<TransactionDto>>> GetAllTransactionsAsync()
//        {
//            var transactions = await transactionRepository.GetAll().Include(tt => tt.TransactionType).Include(tt => tt.Currency).ToListAsync();
//            var dtoList = transactions.Select(tt => new TransactionDto(tt.Id, tt.Amount, tt.Date, tt.TransactionType.Name, tt.Currency.Name)).ToList();

//            return ServiceResult<List<TransactionDto>>.Success(dtoList);
//            //var transactionsDto = mapper.Map<List<TransactionDto>>(transactions);
//            //return ServiceResult<List<TransactionDto>>.Success(transactionsDto);


//        }

//        public Task<ServiceResult<TransactionDto>> GetTransactionByIdAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ServiceResult> UpdateTransactionAsync(int id, CreateTransactionRequest dto)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ServiceResult> UpdateTransactionAsync(int id, int newAmount)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}