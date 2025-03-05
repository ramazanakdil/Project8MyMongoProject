using AutoMapper;
using MongoDB.Driver;
using MyMongoProject.Dtos.CustomerDtos;
using MyMongoProject.Entities;
using MyMongoProject.Settings;

namespace MyMongoProject.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<Department> _departmentCollection;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _departmentCollection = database.GetCollection<Department>(_databaseSettings.DepartmentCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var value = _mapper.Map<Customer>(createCustomerDto);
            await _customerCollection.InsertOneAsync(value);
        }

        public async Task DeleteCustomerAsync(string customerId)
        {
            await _customerCollection.DeleteOneAsync(x => x.CustomerId == customerId);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values);
        }

        public async Task<List<ResultCustomerWithCategoryDto>> GetAllCustomerWithCategoryAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Department = await _departmentCollection.Find(x => x.DepartmentId == item.DepartmentId).FirstAsync();
            }
            return _mapper.Map<List<ResultCustomerWithCategoryDto>>(values);
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(string customerId)
        {
            var values = await _customerCollection.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCustomerDto>(values);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var values = _mapper.Map<Customer>(updateCustomerDto);
            await _customerCollection.FindOneAndReplaceAsync(x => x.CustomerId == updateCustomerDto.CustomerId, values);
        }
    }
}
