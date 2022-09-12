using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TooTipsy.Data;
using TooTipsy.Features.Calculations.DTOs;
using TooTipsy.Features.Calculations.Models;
using TooTipsy.Features.Formulas.Interfaces;
using Microsoft.AspNetCore.Identity;
using TooTipsy.Features.Formulas.Enums;

namespace TooTipsy.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IFormulaFactory _formulaFactory;
    private readonly TipsDbContext _dbcontext;
    private readonly SignInManager<IdentityUser> _signInManager;
    public IndexModel(ILogger<IndexModel> logger
        , IFormulaFactory factory
        , TipsDbContext dbContext
        , SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _formulaFactory = factory;
        _dbcontext = dbContext;
        _signInManager = signInManager;
    }
    [BindProperty]
    public CalculationRequest calculationRequest { get; set; } = default!;
    [BindProperty]
    public decimal Amount { get; set; }

    public IList<Calculation> Calculations { get; set; } = ImmutableList<Calculation>.Empty;

    public async Task<IActionResult> OnGet()
    {
        if (UserLoggedIn())
        {
            return Page();
        }
        Calculations =  await GetMyCalculationsWithNoTrackingAsync(User.Identity!.Name!);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(FormulaType? id)
    {
        try
        {
            if(!ModelState.IsValid || id is null || id == FormulaType.None)
            {
                ModelState.AddModelError(string.Empty, "Model Was Invalid");
                return Page();
            }
            var formula = _formulaFactory.GetFormula((FormulaType)id);
            Amount = formula.CalculateTip(bill: calculationRequest.BillAmount, tax: calculationRequest.TaxAmount);
            if (!UserLoggedIn())
            {
                return Page();
            }
            await _dbcontext.Calculations.AddAsync(new Calculation
            {
                Description = calculationRequest.Description,
                BillAmount = calculationRequest.BillAmount,
                TaxAmount = calculationRequest.TaxAmount,
                TipAmount = Amount,
                FormulaId = (FormulaType)id,
                CreatedDate = DateOnly.FromDateTime(calculationRequest.CreatedDate),
                Username = User.Identity!.Name
            });
            var result = await _dbcontext.SaveChangesAsync();
            if(result is not 1)
            {
                ModelState.AddModelError(string.Empty, "Result Failed To Save");
                return Page();
            }
            return Page();
        }
        catch(Exception ex)
        {
            _logger.LogError("{error}",ex.Message);
            ModelState.AddModelError(string.Empty, ex.Message);
            return Page();
        }
        finally
        {
            if (UserLoggedIn())
            {
                Calculations = await GetMyCalculationsWithNoTrackingAsync(User.Identity!.Name!);
            }
           
        }
    }
    public bool UserLoggedIn()
    {
        return User.Identity is not null &&  _signInManager.IsSignedIn(User) &&  !string.IsNullOrWhiteSpace(User.Identity.Name);
    }
    private async Task<IList<Calculation>> GetMyCalculationsWithNoTrackingAsync(string username)
    {
        return await _dbcontext
           .Calculations
           .Where(calc => calc.Username == username)
           .AsNoTracking()
           .ToListAsync();
    }
}

