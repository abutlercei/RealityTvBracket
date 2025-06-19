using DotNet.Models;
using Microsoft.AspNetCore.Mvc;

public class Repository : DataRepository
{
    private readonly SamplePoolDBContext _context;
    public Repository(SamplePoolDBContext context)
    {
        _context = context;
    }

    public IActionResult GetUserProfile(string username)
    {
        return new OkObjectResult(
            _context.UserProfiles.Find(username)
        );
    }
}