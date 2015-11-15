namespace CategoriesApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public static bool IsValid(Category category)
        {
            return !string.IsNullOrEmpty(category?.Name);
        }
    }
}