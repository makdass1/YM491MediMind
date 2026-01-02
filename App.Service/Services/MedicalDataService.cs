using App.Service.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Services
{
    public class MedicalDataService
    {
        private readonly IConfiguration _config;

        public MedicalDataService(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
                ?? _config.GetConnectionString("SqlServer")
            );
        }

        // 1. Medicines Tablosu
        public async Task<List<MedicineDto>> GetMedicinesAsync()
        {
            var list = new List<MedicineDto>();
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"SELECT TOP (1000) [Id], [Name] FROM [Medicines]", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new MedicineDto
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            return list;
        }

        // 2. Frequency_of_uses Tablosu
        public async Task<List<FrequencyDto>> GetFrequenciesAsync()
        {
            var list = new List<FrequencyDto>();
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"SELECT TOP (1000) [Id], [Name] FROM [Frequency_of_uses]", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new FrequencyDto
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            return list;
        }

        // 3. Allergies Tablosu
        public async Task<List<AllergyDto>> GetAllergiesAsync()
        {
            var list = new List<AllergyDto>();
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"SELECT TOP (1000) [Id], [Name] FROM [Allergies]", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new AllergyDto
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            return list;
        }

        // 4. UserAllergies Tablosu
        public async Task<List<UserAllergyDto>> GetUserAllergiesAsync()
        {
            var list = new List<UserAllergyDto>();
            using var conn = GetConnection();
            await conn.OpenAsync();

            // SQL'de kolon isimlerine dikkat ettim: UsersId ve allergiesId
            var cmd = new SqlCommand(@"SELECT TOP (1000) [UsersId], [allergiesId] FROM [UserAllergies]", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new UserAllergyDto
                {
                    UsersId = reader.GetInt32(0),
                    AllergiesId = reader.GetInt32(1)
                });
            }
            return list;
        }
    }
}