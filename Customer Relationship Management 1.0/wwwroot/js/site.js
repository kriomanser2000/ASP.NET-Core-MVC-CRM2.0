// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showUsers()
{
    fetch('@Url.Action("Index", "Users")')
        .then(response => response.text())
        .then(html =>
        {
            document.getElementById('content').innerHTML = html;
        });
}