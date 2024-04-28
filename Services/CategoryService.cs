public class CategoryService
{
    // users api 
    public static List<Category> _categories = new List<Category>() {
    new Category{
        CategoryId = Guid.Parse("75424b9b-cbd4-49b9-901b-056dd1c6a020"),
        Name = "smart-phone",
        Description = "hello I am a beautiful phone",
        CreatedAt = DateTime.Now
    },
    new Category{
        CategoryId = Guid.Parse("24508f7e-94ec-4f0b-b8d6-e8e16a9a3b29"),
        Name = "cloths",
        Description = "hello I am a beautiful cloths",
        CreatedAt = DateTime.Now
    },
    new Category{
        CategoryId = Guid.Parse("87e5c4f3-d3e5-4e16-88b5-809b2b08b773"),
        Name = "food",
        Description = "hello I am a beautiful food",
        CreatedAt = DateTime.Now
    }
};

    public IEnumerable<Category> GetAllCategoryService()
    {
        return _categories;
    }
    public Category? GetCategoryById(Guid categoryId)
    {
        return _categories.Find(category => category.CategoryId == categoryId);
    }
    public Category CreateCategoryService(Category newCategory)
    {
        newCategory.CategoryId = Guid.NewGuid();
        newCategory.CreatedAt = DateTime.Now;
        _categories.Add(newCategory); // store this user in our database
        return newCategory;
    }
    public Category UpdateCategoryService(Guid categoryId, Category updateCategory)
    {
        var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (existingCategory != null)
        {
            existingCategory.Name = updateCategory.Name;
            existingCategory.Description = updateCategory.Description;

        }
        return existingCategory;
    }
    public bool DeleteCategoryService(Guid categoryId)
    {
        var categoryToRemove = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (categoryToRemove != null)
        {
            _categories.Remove(categoryToRemove);
            return true;
        }
        return false;
    }

}