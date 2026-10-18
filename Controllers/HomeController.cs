
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_talashkevich.Models;

namespace wt_lab4_4mvc_talashkevich.Controllers;

public class HomeController : Controller
{
    private static readonly List<Member> Members = new()
    {
        new Member { Id = 1, Name = "Анна Петрова", Age = 22, MembershipType = "Премиум", IsActive = true },
        new Member { Id = 2, Name = "Максим Иванов", Age = 25, MembershipType = "Стандарт", IsActive = true },
        new Member { Id = 3, Name = "Елена Смирнова", Age = 21, MembershipType = "Студенческий", IsActive = true },
        new Member { Id = 4, Name = "Дмитрий Козлов", Age = 30, MembershipType = "Стандарт", IsActive = false },
        new Member { Id = 5, Name = "София Морозова", Age = 24, MembershipType = "Премиум", IsActive = true }
    };

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult MembersList()
    {
        return View(Members);
    }

    public IActionResult Details(int id)
{
    var member = Members.FirstOrDefault(m => m.Id == id);

    if (member == null)
    {
        return NotFound();
    }

    return View(member);
}


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MemberCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        int newId = Members.Count == 0 ? 1 : Members.Max(m => m.Id) + 1;

        var member = new Member
        {
            Id = newId,
            Name = model.Name,
            Age = model.Age,
            MembershipType = model.MembershipType,
            IsActive = true
        };

        Members.Add(member);

        return RedirectToAction(nameof(MembersList));
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var member = Members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            return NotFound();
        }

        var model = new MemberCreateViewModel
        {
            Name = member.Name,
            Age = member.Age,
            MembershipType = member.MembershipType
        };

        ViewBag.MemberId = member.Id;

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, MemberCreateViewModel model)
    {
        var member = Members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            ViewBag.MemberId = id;
            return View(model);
        }

        member.Name = model.Name;
        member.Age = model.Age;
        member.MembershipType = model.MembershipType;

        return RedirectToAction(nameof(MembersList));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var member = Members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            return NotFound();
        }

        Members.Remove(member);

        return RedirectToAction(nameof(MembersList));
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
