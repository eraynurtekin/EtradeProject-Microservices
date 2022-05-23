using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourses.Shared.Dtos;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            var responseListCategories = _mapper.Map<List<CategoryDto>>(categories);
            return Response<List<CategoryDto>>.Success(responseListCategories, 200);
        }
        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
           await _categoryCollection.InsertOneAsync(category);
           var insertCategory = _mapper.Map<CategoryDto>(category);
           return Response<CategoryDto>.Success(insertCategory,200); 
        }
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.FindAsync(id); // Değişiklik olabilir.

            if(category == null) {             
                return Response<CategoryDto>.Fail("Category not found", 404);
            }

            var getCategory = _mapper.Map<CategoryDto>(category);
            return Response<CategoryDto>.Success(getCategory,200);
        }

    }
}
