﻿using Microsoft.AspNetCore.Mvc;
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
            ViewData["error_message"] = string.IsNullOrEmpty(form.Message);

            return CurrentUmbracoPage();
        }
       

        var result = await _httpClient.PostAsJsonAsync("https://emailprovider-onatrix.azurewebsites.net/api/FormDataSaver?code=FvkA63ESnBZeOg0EEBdznDsPtgJd9oGYyOnXp-vtMlHlAzFuoQOEAw%3D%3D", form);
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

    [HttpPost]
    public async Task<IActionResult> HandleSubmitEmailForm(ContactEmailForm form)
    {
        if (!ModelState.IsValid)
        {
            ViewData["email"] = form.Email;
            ViewData["error_email"] = string.IsNullOrEmpty(form.Email);

            return CurrentUmbracoPage();
        }


        var result = await _httpClient.PostAsJsonAsync("https://emailprovider-onatrix.azurewebsites.net/api/FormDataSaver?code=FvkA63ESnBZeOg0EEBdznDsPtgJd9oGYyOnXp-vtMlHlAzFuoQOEAw%3D%3D", form);
        if (result.IsSuccessStatusCode)
        {
            TempData["successemail"] = "Thank you, email submitted successfully";
            return RedirectToCurrentUmbracoPage();
        }
        else
        {
            TempData["failed"] = "Could not send your request, please try again";
            return RedirectToCurrentUmbracoPage();
        }
    }
}