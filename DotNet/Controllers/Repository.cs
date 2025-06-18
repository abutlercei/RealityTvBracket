public class Repository : DataRepository
{
    private readonly SamplePoolDBContext _context;
    public Repository(SamplePoolDBContext context)
    {
        _context = context;
    }
}