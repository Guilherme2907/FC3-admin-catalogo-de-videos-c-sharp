using Codeflix.Catalog.Domain.Exceptions;
using Codeflix.Catalog.Domain.SeedWork;
using Codeflix.Catalog.Domain.Validation;

namespace Codeflix.Catalog.Domain.Entity;

public class Genre : AggregateRoot
{
    public string Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; }

    public IReadOnlyList<Guid> Categories => _categories;

    private readonly List<Guid> _categories;

    public Genre(string name, bool isActive = true)
    {
        Name = name;
        IsActive = isActive;
        CreatedAt = DateTime.Now;
        _categories = new List<Guid>();

        Validate();
    }

    public void Activate()
    {
        IsActive = true;

        Validate();
    }

    public void Deactivate()
    {
        IsActive = false;

        Validate();
    }

    public void Update(string newName)
    {
        Name = newName;

        Validate();
    }

    public void AddCategory(Guid category)
    {
        _categories.Add(category);
    }

    public void RemoveCategory(Guid category)
    {
        _categories.Remove(category);
    }

    public void RemoveAllCategories()
    {
        _categories.Clear();
    }

    public void Validate()
    {
        DomainValidation.NotNullOrEmpty(Name, nameof(Name));
    }
}
