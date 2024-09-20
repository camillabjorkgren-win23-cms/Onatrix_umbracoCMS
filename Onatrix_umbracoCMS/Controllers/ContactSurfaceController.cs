using Microsoft.AspNetCore.Mvc;
using Onatrix_umbracoCMS.Models;
using System.Net.Http.Json;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;


namespace Onatrix_umbracoCMS.Controllers;

public class ContactSurfaceController : SurfaceController
{
    private readonly HttpClient _httpClient;

    public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, HttpClient httpClient) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _httpClient = httpClient;
    }


    [HttpPost]
    public async Task<IActionResult> HandleSubmit(ContactFormModel form)
    {
        if(!ModelState.IsValid)
        {
            ViewData["name"] = form.Name;
            ViewData["email"] = form.Email;
            ViewData["phone"] = form.Phone;
            ViewData["message"] = form.Message;
            ViewData["subject"] = form.Subject;

            ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
            ViewData["error_email"] = string.IsNullOrEmpty(form.Email);
            ViewData["error_phone"] = string.IsNullOrEmpty(form.Phone);
            ViewData["error_message"] = string.IsNullOrEmpty(form.Message);
            ViewData["error_subject"] = string.IsNullOrEmpty(form.Subject);

            return CurrentUmbracoPage();
        }
       

        var result = await _httpClient.PostAsJsonAsync("http://localhost:7057/api/FormDataSaver",form);
        if (result.IsSuccessStatusCode)
        {
            TempData["success"] = "Thank you, form submitted successfully";
            return RedirectToCurrentUmbracoPage();
        }
        else
        {
            TempData["failed"] = "Could not send your request, please try again";
            return RedirectToCurrentUmbracoPage();
        }
    }
}