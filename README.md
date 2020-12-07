# Telerik Demo

Notes - 
This example used a 3rd party library called using Kendo.DynamicLinqCore; other options might be available now. At the time teleriks own open sourced dynamic linq code didnt work an is an un-maintaned repo. Alternative might require dependencies on Teleriks Kendo MVC stack

Demo telerik kendo grid project that fully uses Ajax CRUD, on a sizeable 700 row dataset, uses minimal telerik css/js and only one third party .net core version of an open sourced telerik serverside API for dynamic paging/filtering and sorting using Linq.

Rather than including the full monolithic kendo ui framework the samples use a minimal js file built using a custom telerik build file see: https://www.telerik.com/download/custom-download
This example also used the Telerik Date Time picker instead of the date picker for grid filtering so it must be included in addition to the standard grid dependencies.
![alt text](https://github.com/idbates/TelerikDemo/blob/master/TelerikDemo/wwwroot/builder.png)

# Telerik Documentation

 Telerik provides their own demo pages here
 https://demos.telerik.com/kendo-ui/grid/index
 
 The overview of the grid with examples can be found here
 https://docs.telerik.com/kendo-ui/controls/data-management/grid/overview
 
 The kendo DataSource overview can be found here https://docs.telerik.com/kendo-ui/framework/datasource/overview
 
 The API documentation for the Grid can be found here
 https://docs.telerik.com/kendo-ui/api/javascript/ui/grid
 
 The kendo DataSource is a key component used by the grid
 https://docs.telerik.com/kendo-ui/api/javascript/data/datasource
 
# Grid Dynamic Filtering and Paging

 https://www.telerik.com/blogs/kendo-ui-open-sources-dynamic-linq-helpers
 https://github.com/linmasaki/Kendo.DynamicLinqCore 

# Theming the grid

Telerik Sass Theme Builder https://themebuilder.telerik.com/kendo-ui 

# 
