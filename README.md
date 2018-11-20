# Angular 6 - Visual studio Template for DNN 9.x.
This is a scaffold DNN 9.x module template for and Angular 6.

# Description
To Develop Angular 6 project with DNN you need 2 different project:
1. Angular CLI project (template-dnn-7.x-for-angular-6-CLI)
2. DNN 9.x module that host your angular **(this project)**

This is a best practice for your developer frontend, because it is independent from DNN.

Frontend developer should love it.

# Issues resolved with DNN 7.x and Angular 6
1. How to develop your Angular CLI (Tested for Angular CLI: 6.1.2) and deploy inside DNN 9.x.
2. How to pass information from DNN to Angular
3. How to use DNN webapi and angular

# Features
A SPA module has no ascx file as control. Instead it uses a html file.
## In your index.html you should have:

### AntiForgery Token
This token is usefull for webapi call security.

```
[AntiForgeryToken:true]
```


### All angular css and library
```
[Css:{ path: "https://fonts.googleapis.com/icon?family=Material+Icons"}]
[JavaScript:{ path: "~/DesktopModules/AngularNGMD/dist/main.js", priority:100, provider: "DnnFormBottomProvider"}]
[JavaScript:{ path: "~/DesktopModules/AngularNGMD/dist/polyfills.js", priority:100, provider: "DnnFormBottomProvider"}]
[JavaScript:{ path: "~/DesktopModules/AngularNGMD/dist/runtime.js", priority:100, provider: "DnnFormBottomProvider"}]
[JavaScript:{ path: "~/DesktopModules/AngularNGMD/dist/styles.js", priority:100, provider: "DnnFormBottomProvider"}]
[JavaScript:{ path: "~/DesktopModules/AngularNGMD/dist/vendor.js", priority:100, provider: "DnnFormBottomProvider"}]
```

### Automatic Routing with Angular app
```html
<base href="[ModuleProperties:rawurl]">
```

### Your angular tag selector

```html
<app-root>
    <p>Loading....</p>
</app-root>
```

### Passing information from DNN to Angular:
The solution is to pass to window object all DNN information needed to process correctly your angular app in DNN enviroment.
Example: to get resx resources from your module or call DNN webapi.

In your html page you just need to add this script
```javascript
<script>
    window["AngularNGMD"] = [ModuleProperties:All]
</script>
```

Example of script result after DNN parsing the HTML page:
```javascript
window[
    "AngularNG"
] = {
    "Resources": {
        "BasicSettings_Text": "Basic Client Centric Settings",
        "CollapseAll_Text": "Collapse All",
        "ConfirmDelete_Text": "Are you sure you want to delete this Item",
        "DeleteItem_Text": "Delete",
        "EditItem_Text": "Edit",
        "AddItem_Text": "Add Item",
        "lblAssignedUser_Text": "Assigned User",
        "lblDescription_Text": "Description",
        "lblName_Text": "Name",
        "NoRecords_Text": "No items exists in the database",
        "reqAssignedUser_Text": "Assigned user is required",
        "reqDescription_Text": "Description is required",
        "reqTitle_Text": "Title is required",
        "minTitle_Text": "Minimum title length: 5",
        "CancelEdit_Text": "Cancel",
        "SaveEdit_Text": "Save",
        "NewItem_Description": "Add new item by clicking here",
        "NewItem_Text": "New item"
    },
    "Settings": {},
    "IsEditable": false,
    "EditMode": false,
    "IsAdmin": false,
    "ModuleId": 382,
    "PortalId": 0,
    "UserId": -1,
    "HomeDirectory": "Portals/0/",
    "ModuleDirectory": "/DesktopModules/AngularNG/",
    "RawUrl": "/AngularNG6",
    "PortalLanguages": [
        "it-IT"
    ],
    "CurrentLanguage": "it-IT",
    "Users": [
        {
            "text": "demo123",
            "id": 2
        }
    ]
}
```

#Links:

`<link>` : https://github.com/DnnFree/awesome-dnn

###tokens to support building pure SPA modules
`<link>` : https://www.dnnsoftware.com/community-blog/cid/155247/module-development-in-dnn-8-5--new-tokens-to-support-building-pure-spa-modules

