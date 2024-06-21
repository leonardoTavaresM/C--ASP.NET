using ScreenSound.Models;

namespace ScreenSound.DB;

public class DAL<T> where T : class
{
    private readonly ScreenSoundContext context;

    public DAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> List()
    {
        return context.Set<T>().ToList();
    }

    public IEnumerable<T> ListBy(Func<T, bool> condition)
    {
        return context.Set<T>().Where(condition);
    }

    public  void Add(T obj)
    {
        context.Set<T>().Add(obj);
        context.SaveChanges();
    }
    public void Update(T obj)
    {
        context.Set<T>().Update(obj);
        context.SaveChanges();
    }
    public void Delete(T obj)
    {
        context.Set<T>().Remove(obj);
        context.SaveChanges();
    }

    public T GetBy(Func<T, bool> condition)
    {
        return context.Set<T>().FirstOrDefault(condition);
    }

}
