# SPA HTML Module - Visual studio Template for DNN 9.x for Angular 6.x and 7.x
This is a scaffold DNN 9.x module template for Angular 6/7.

# Video on youtube: https://www.youtube.com/watch?v=G1E3HblfN_8

# Description
To Develop Angular 6 project with DNN you need 2 different project:

1. Angular 6/7 - CLI Template for DNN 7.x, 8.x, 9.x.
`<link>` : https://github.com/OPSI-srl/DNN-Angular-6-7-CLI

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

# What you need to do step by step:
1. Create a Folder (example: "Demo-Angular6") inside your DNN /desktopmodule/Demo-Angular6/
2. Clone this project from git inside /desktopmodule/Demo-Angular6/ (all files should be in root folder)
3. Open solution (filename.sln) with visual studio 2015
4. Re-naming the project/solution
5. Change Assembly name and Namespace
6. Build your solution and check any error.
7. It's time to register Module inside your DNN
- Login as host.
- Go to host->Estension->Create new module
- select control module 
- "folder name"
- "Business Controller": [namespace].Controller.BusinessController,[namespace] (ex. AngularNGMD.Controller.BusinessController,AngularNGMD) 
- insert module name: Demo Angular 6
- Add "Module definition"
- Add "Module control (folder, source file: index.html, Type: view)"

# Reference
This project is just an avolution or code encapsulation made from these important resources by Torsten Weggen and Danile Mettler:

`<link>` : http://www.bitboxx.net/Blog/Post/525/DNN-module-development-with-Angular-2-Part-7#/

`<link>` : https://2sxc.org/en/blog/post/how-to-correctly-connect-dnn-to-angular-4-5-using-reactive-javascript

`<link>` : https://github.com/2sic/dnn-sxc-angular
