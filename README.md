## UploadEmailAttachments_20211215
1. ASP.NET Web Application(.NET Framework) > MVC
2. Add new controller > create(To upload product pictures) > Add Create()
3. Create ViewModel > add new class as "EmailVM"
4. Create View page (by clicking controller > ActuionResult Create(){})
5. Edit `@using (Html.BeginForm("Create", "Messages", FormMethod.Post, new { enctype = "multipart/form-data" }))`
6. Manually create below code: 
```C# =    
<div class="form-group">
        @Html.LabelFor(model => model.ToAttachFile, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            <input type="file" name="ToAttachFile" value="form-control" />
            @Html.ValidationMessageFor(model => model.ToAttachFile, "", new { @class = "text-danger" })
        </div>
    </div>
```
7. Run `Create.cshtml`
